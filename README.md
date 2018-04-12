# Клиент для REST API Сервиса скрининга лекарственных назначений (СЛН-Сервис)

Здесь представлен пример клиента для СЛН-Сервиса.

Код написан с использованием Visual Studio 2017, .NET Framework 4.5.2 и языка C# версии 7.

## Общая информация по REST API

Данный клиент покрывает всю функциональность, предоставляемую СЛН-сервисом:
- Получение типов концептов
- Поиск концептов
- Получение концепта
- Выполнение скрининга

С описанием всех ресурсов REST API, их параметров и результатов можно получить 
на [странице справки][api-help].

Общая информация о СЛН-Сервисе доступна в репозитории [sln][common-help].

### Создание клиента

```csharp
var credentials = new ClientCredentials("login", "password");
var client = new ApiClient("http://int.drugscreening.ru/v1", credentials);
```
Получение и обновление токена не требуется, т.к. клиент сам следит за наличием токена
и его получением или обновлением при необходимости.

### Получение списка типов концептов

```csharp
var types = await client.GetConceptTypesAsync();
```

### Получение всех концептов определенного типа

```csharp
// получение списка концептов типа "DispensableDrug"
var concepts = await client.ListConceptsAsync("DispensableDrug");
```

### Поиск концептов

```csharp
// среди концептов, типы которых задаются областью поиска
var concepts = await client.FindConceptsAsync("аспирин", SearchMethod.Text, SearchScope.Drugs);
```
или
```csharp
// среди концептов указанных типов
var concepts = await client.FindConceptsAsync("аспирин", SearchMethod.Text, "DispensableDrug", "Substance");
```

#### Примеры
Поиск среди всех препаратов и субстанций:
```csharp
var concepts = await client.FindConceptsAsync("аспирин", SearchMethod.Text, SearchScope.DrugsAndSubstances);
```

Поиск среди всех концептов, которые могут быть указаны в качестве аллергенов:
```csharp
var concepts = await client.FindConceptsAsync("пыль", SearchMethod.Text, SearchScope.Allergens);
```

Поиск диагнозов и заболеваний:
```csharp
var diseases = await client.FindConceptsAsync("ангина", SearchMethod.Text, SearchScope.Diseases);
```

Кроме поиска по тексту, доступны 
1. поиск по штрихкоду препарата (SearchMethod.Barcode)
2. по точному совпадению названия (SearchMethod.ExactName)

Например, следующий код вернет все препараты, штрихкод которых равен 123456789012:
```csharp
// поиск по штрихкоду
var concepts = await client.FindConceptsAsync("123456789012", SearchMethod.Barcode, "DispensableDrug", "Substance");
```

### Получение концепта

```csharp
var concept = await client.GetConceptAsync("DispensableDrug", "DD0000800");
```

### Скрининг
```csharp
// выполнение скрининга
var request = new ScreenRequest()
{
    // информация о пациенте
    Patient = new Patient()
    {
        BirthDate = new DateTime(2002, 2, 16),
        Gender = Gender.Female,
        Sport = new PatientSport()
        {
            Code = "NSP00087",
            Name = "Сноуборд (Лыжный спорт/сноубординг (FIS))",
            Period = CompetitionPeriod.InCompetition,
            Role = "Athlete"
        }
    },
    // список препаратов, субстанций и БАДов
    Drugs = new List<Drug>()
    {
        new Drug()
        {
            Type = "Substance",
            Code = "SUB000007",
            Name = "Боластерон"
        },
        new Drug()
        {
            Type = "DispensableDrug",
            Code = "DD0000800", 
            Name = "Аспирин табл. 100мг"
        },
        new Drug()
        {
            Type = "DispensableDrug",
            Code = "DD0009389",
            Name = "Варфарекс табл. 3мг",
            Schedule = new AdministrationSchedule()
            {
                FirstAdministration = DateTime.Today.AddDays(-1),
                LastAdministration = DateTime.Today.AddDays(4)
            }
        }
    },
    // Список аллергий, имеющихся у пациента.
    // В качестве аллергенов могут быть указаны концепты
    // следующих типов:
    // DispensableDrug, GenericDrug, GenericName, DrugName,
    // AllergenClass и ScreenableIngredient
    Allergies = new List<Allergy>()
    {
        new Allergy()
        {
            Type= "AllergenClass",
            Code= "ALGC0029",
            Name= "Салицилаты"
        },
        new Allergy()
        {
            Type = "ScreenableIngredient",
            Code = "SI002679",
            Name = "Варфарин"
        }
    },
    // Список заболеваний пациента.
    // На данный момент поддерживаются только 
    // диагнозы в соответствии с МКБ-10
    Diseases = new List<Disease>()
    {
        new Disease()
        {
            Type = "ICD10CM",
            Code = "D69.5",
            Name = "Вторичная тромбоцитопения"
        }
    },
    Options = new ScreeningOptions()
    {
        IncludeMonographs = true,
        IncludeInsignificantInactiveIngredients = true
    }
};

var result = await client.ScreenAsync(request);

// получение обобщенного уровня риска для взаимодействия
var severity = result.DrugDrugInteractions.Items[0].GetGenericSeverity();

// получение реферата в формате HTML
var html = result.AllergicReactions.Items[0].GetMonographHtml();
```

Для преобразования реферата в HTML используется XSL-шаблон, хранящийся в ресурсах.
Вместо него можно использовать свой шаблон, для этого необходимо выполнить следующий код:
```csharp
MonographHelper.UseCustomStylesheet(customXsltTransform)
```

#### Внешние справочники

При выполнении скрининга допустимо указывать идентификаторы лекарственных препаратов из "внешних" справочников.
На данный момент ограниченно поддерживаются справочники:
- РЛС (Россия, https://www.rlsnet.ru)
- CBZ (Centralna Baza Zdravil, Словения, http://www.cbz.si)

В связи с тем, что эти справочники ведутся и постоянно обновляются сторонними организациям, 
не все их позиции известны сервису. Поэтому для некоторых идентификаторов сервисом может 
быть возвращено сообщение `DrugNotFound`.

```csharp
// Получение типов концептов внешних справочников
var externalTypes = await client.GetExternalConceptTypesAsync();

// Препарат из таблицы NOMEN БД РЛС
var drug = new Drug()
{
    Type = "urn:rlsnet:nomen", // тип внешнего концепта
    Code = "11835", // Значение поля ID таблицы NOMEN
    Name = "Аспирин® табл. 100 мг (10 бл., 2 кор.), Пр: Bayer Bitterfeld GmbH (Германия)"  // Название в соответствии со справочником
}

// Препарат из справочника CBZ (Centralna Baza Zdravil, Словения)
var drug = new Drug()
{
    Type = "urn:slovenia:cbz", // тип внешнего концепта
    Code = "048836", // Значение "Nacionalna šifra zdravila", ведущие нули обязательны
    Name = "ASPIRIN direkt 500 mg žvečljive tablete"  // Название в соответствии со справочником
}
```

Значение поля `Name` не обязательно должно быть точно таким же, как в исходном справочнике.
Тем не менее, следует иметь в виду, что переданное название будет использовано в текстах ответа сервиса.

### Инструкции к лекарственным препаратам

```csharp
// получение списка инструкций для препарата
var instructions = await client.ListInstructionsAsync("DispensableDrug", "DD0009391");

// получение описания инструкции и содержимого в формате XML
var instruction = await client.GetInstructionAsync("a32d6a19-a1c6-47fd-ad95-1a6e58e92212");

// преобразование содержимого инструкции в формат HTML
var instructionHtml = instruction.GetContentAsHtml();
```

Для преобразования инструкции в HTML используется XSL-шаблон, хранящийся в ресурсах.
Вместо него можно использовать свой шаблон, для этого необходимо выполнить следующий код:

```csharp
InstructionHelper.UseCustomStylesheet(customXsltTransform)
```

---------------------

### Рекомендации по использованию API
Для улучшения работы сервиса и сокращения времени, требуемого на обработку запроса, рекомендуется придерживаться определенных правил.
 
#### Количество лекарственных препаратов, аллергий и диагнозов
Так как сервис выполняет скрининг по принципу «каждый с каждым», увеличение количества 
входных параметров приводит к значительному росту времени обработки. Например, если 
запрошен скрининг взаимодействий препарат-препарат для 10 лекарственных средств, сервисом 
будет выполнено 45 проверок, а для 100 препаратов - уже 4950. Если учесть, что каждая 
проверка может занимать от 1 до 20 миллисекунд, то время, необходимое только для выполнения 
одного этого вида скрининга, может составить около 1 секунды для 10 препаратов и до 2-х 
минут для 100 препаратов. Если же запрошено выполнение всех видов скрининга, время обработки 
запроса по 100 препаратом приблизится к 10-15 минутам.

#### Изделия медицинского назначения, не являющиеся лекарственными средствами

В список препаратов следует включать только лекарственные средства (имеющие регистрационное 
удостоверение лекарственного средства), БАДы и субстанции, которые требуется проверить. 
Не следует включать в запрос изделия медицинского назначения, такие, как 
«Вата» или «Шприц медицинский».
 
#### Назначения без расписания приема

Поле `Drug.Schedule` желательно целиком исключить из запроса для тех препаратов, 
у которых не определена дата начала приема.

#### Последовательные назначения
Необходимо объединять в одно назначение несколько назначений одного и 
того же препарата, если периоды приема следуют друг за другом без перерыва. 

Например, если препарат первый раз назначен с 10 по 12 февраля, а затем 
с 13 по 16 февраля, в запросе этот препарат следует указывать только один 
раз с периодом приема с 10 по 16 февраля.


[api-instance]: https://int.drugscreening.ru/v1/
[api-help]: https://int.drugscreening.ru/v1/help
[common-help]: ../sln
