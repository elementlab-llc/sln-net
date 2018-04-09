<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes" />
  <xsl:param name="documentuniqueid"></xsl:param>
  <xsl:param name="InstructionNameShow">1</xsl:param>
  <xsl:param name="TradeNameShow">1</xsl:param>
  <xsl:param name="MnnShow">1</xsl:param>
  <xsl:param name="RegistrationNumberShow"></xsl:param>
  <xsl:param name="RegistrationDateShow"></xsl:param>
  <xsl:param name="EndDateShow"></xsl:param>
  <xsl:param name="NullDateShow"></xsl:param>
  <xsl:param name="InformationRenewDateShow">1</xsl:param>
  <xsl:param name="SynonymsShow"></xsl:param>
  <xsl:param name="DrugFormShow">1</xsl:param>
  <xsl:param name="AtcShow">1</xsl:param>
  <xsl:param name="CompositionShow">1</xsl:param>
  <xsl:param name="DescriptionShow">1</xsl:param>
  <xsl:param name="PharmacotherapeuticGroupShow">1</xsl:param>
  <xsl:param name="PharmacoDynamicsShow">1</xsl:param>
  <xsl:param name="PharmacoKineticsShow">1</xsl:param>
  <xsl:param name="IndicationsShow">1</xsl:param>
  <xsl:param name="CounterIndicationsShow">1</xsl:param>
  <xsl:param name="WithCareShow">1</xsl:param>
  <xsl:param name="PregnancyAndLactationShow">1</xsl:param>
  <xsl:param name="DosingAndAdministrationShow">1</xsl:param>
  <xsl:param name="SideEffectsShow">1</xsl:param>
  <xsl:param name="OverdoseShow">1</xsl:param>
  <xsl:param name="InteractionShow">1</xsl:param>
  <xsl:param name="SpecialInstructionsShow">1</xsl:param>
  <xsl:param name="MachineryOperationShow">1</xsl:param>
  <xsl:param name="FormDosageShow">1</xsl:param>
  <xsl:param name="PackageShow"></xsl:param>
  <xsl:param name="StorageConditionsShow"></xsl:param>
  <xsl:param name="ShelfLifeShow"></xsl:param>
  <xsl:param name="ConditionsOfSupplyShow"></xsl:param>
  <xsl:param name="ManufacturersShow">1</xsl:param>
  <xsl:param name="RegistrationCertificateOwnerShow"></xsl:param>
  <xsl:param name="RepresentativesShow">1</xsl:param>

  <!--BAA Sections-->
  <xsl:param name="UsageAreaShow">1</xsl:param>
  <xsl:param name="RecommendationsShow">1</xsl:param>
  <xsl:param name="ResearchProtocolsShow">1</xsl:param>
  <!-- /BAA Sections-->

  <xsl:variable name="TradeNameSectionName" select="'Торговое наименование'" />
  <xsl:variable name="MnnSectionName" select="'Действующее вещество'" />
  <xsl:variable name="RegistrationNumberSectionName" select="'Регистрационный номер'" />
  <xsl:variable name="RegistrationDateSectionName" select="'Дата регистрации'" />
  <xsl:variable name="EndDateSectionName" select="'Дата окончания'" />
  <xsl:variable name="NullDateSectionName" select="'Дата аннулирования'" />
  <xsl:variable name="InformationRenewDateSectionName" select="'Дата обновления информации'" />
  <xsl:variable name="SynonymsSectionName" select="'Аналогичные препараты'" />
  <xsl:variable name="RepresentativesSectionName" select="'Представительства'" />
  <xsl:variable name="DrugFormSectionName" select="'Лекарственная форма'" />
  <xsl:variable name="AtcSectionName" select="'АТХ'" />
  <xsl:variable name="CompositionSectionName" select="'Состав'" />
  <xsl:variable name="DescriptionSectionName" select="'Описание'" />
  <xsl:variable name="PharmacotherapeuticGroupSectionName" select="'Фармакотерапевтическая группа'" />
  <xsl:variable name="PharmacoDynamicsSectionName" select="'Фармакодинамика'" />
  <xsl:variable name="PharmacoKineticsSectionName" select="'Фармакокинетика'" />
  <xsl:variable name="IndicationsSectionName" select="'Показания'" />
  <xsl:variable name="CounterIndicationsSectionName" select="'Противопоказания'" />
  <xsl:variable name="WithCareSectionName" select="'С осторожностью'" />
  <xsl:variable name="PregnancyAndLactationSectionName" select="'Беременность и грудное вскармливание'" />
  <xsl:variable name="DosingAndAdministrationSectionName" select="'Способ применения и дозы'" />
  <xsl:variable name="SideEffectsSectionName" select="'Побочные эффекты'" />
  <xsl:variable name="OverdoseSectionName" select="'Передозировка'" />
  <xsl:variable name="InteractionSectionName" select="'Взаимодействие'" />
  <xsl:variable name="SpecialInstructionsSectionName" select="'Особые указания'" />
  <xsl:variable name="MachineryOperationSectionName" select="'Влияние на способность управлять трансп. ср. и мех.'" />
  <xsl:variable name="FormDosageSectionName" select="'Форма выпуска/дозировка'" />
  <xsl:variable name="PackageSectionName" select="'Упаковка'" />
  <xsl:variable name="StorageConditionsSectionName" select="'Условия хранения'" />
  <xsl:variable name="ShelfLifeSectionName" select="'Срок годности'" />
  <xsl:variable name="ConditionsOfSupplySectionName" select="'Условия отпуска из аптек'" />
  <xsl:variable name="RegistrationCertificateOwnerSectionName" select="'Владелец Регистрационного удостоверения'" />
  <xsl:variable name="ManufacturersSectionName" select="'Производители'" />

  <!--BAA Sections Names-->
  <xsl:variable name="UsageAreaSectionName" select="'Область применения'" />
  <xsl:variable name="RecommendationsSectionName" select="'Рекомендации'" />
  <xsl:variable name="ResearchProtocolsSectionName" select="'Протоколы исследований'" />
  <!--/ BAA Sections Names-->

  <xsl:template name="Header">
    <head>
      <meta name="viewport" content="width=device-width, initial-scale=1.0" />
      <title>
        <xsl:value-of select="InstructionName" />
      </title>

      <style type="text/css">
        * {
        font-size: 14px;
        font-family: Arial;
        -webkit-hyphenate-character: '-';
        }
        .TradeNameSection, .Mnn, .DrugForm { margin-bottom: 10px; }
        .InstructionName { font-weight: bold; font-size: 20px; margin-bottom: 10px;}
        .Section { margin-top: 10px; margin-bottom: 5px; }
        .CompositionContent p { display: inline; }
        .CompositionContent i { font-style: normal; }

        .HtmlContent span div:first-child {display: inline;}

        .HtmlContent span p:first-child {display: inline;}

        .HtmlContent p {margin-bottom: 0px; margin-top: 0px;}

        table { width: 95%; margin-bottom: 10px; margin-top: 10px;}

        tr, td, th, thead, tfoot {
        page-break-inside: avoid !important;
        }

        img.auto-page-break {
        page-break-before: auto;
        page-break-inside: avoid;
        }

        img {
        max-width:100%;
        }

        .HeaderPanel {
        float: left;
        margin-left: 10px;
        }

        .HeaderContainer {
        -moz-column-count: 2;
        -webkit-column-count: 2;
        column-count: 2;
        padding: 10px 0;
        }

        .HeaderContainer > ul {
        list-style-type: none;
        margin: 0;
        padding-left:0;
        }
      </style>
    </head>
  </xsl:template>

  <xsl:template match="Drug">
    <html>
      <xsl:call-template name="Header" />
      <body>

        <xsl:apply-templates select="InstructionName" />

        <div class="HeaderContainer">
          <ul>
            <xsl:if test="TradeName and $TradeNameShow">
              <li>
                <a href="#TradeNameSection">
                  <xsl:value-of select="$TradeNameSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="Mnn and $MnnShow">
              <li>
                <a href="#MnnSection">
                  <xsl:value-of select="$MnnSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='RegistrationNumber'] and $RegistrationNumberShow">
              <li>
                <a href="#RegistrationNumberSection">
                  <xsl:value-of select="$RegistrationNumberSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="RegistrationDate and $RegistrationDateShow">
              <li>
                <a href="#RegistrationDateSection">
                  <xsl:value-of select="$RegistrationDateSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="EndDate and $EndDateShow">
              <li>
                <a href="#EndDateSection">
                  <xsl:value-of select="$EndDateSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="NullDate and $NullDateShow">
              <li>
                <a href="#NullDateSection">
                  <xsl:value-of select="$NullDateSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="InformationRenewDate and $InformationRenewDateShow">
              <li>
                <a href="#InformationRenewDateSection">
                  <xsl:value-of select="$InformationRenewDateSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="Synonyms and $SynonymsShow">
              <li>
                <a href="#SynonymsSection">
                  <xsl:value-of select="$SynonymsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="Manufacturers and $ManufacturersShow">
              <li>
                <a href="#ManufacturersSection">
                  <xsl:value-of select="$ManufacturersSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="Representatives and $RepresentativesShow">
              <li>
                <a href="#RepresentativesSection">
                  <xsl:value-of select="$RepresentativesSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='DrugForm'] and $DrugFormShow">
              <li>
                <a href="#DrugFormSection">
                  <xsl:value-of select="$DrugFormSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="Atc and $AtcShow">
              <li>
                <a href="#AtcSection">
                  <xsl:value-of select="$AtcSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Composition'] and $CompositionShow">
              <li>
                <a href="#CompositionSection">
                  <xsl:value-of select="$CompositionSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Description'] and $DescriptionShow">
              <li>
                <a href="#DescriptionSection">
                  <xsl:value-of select="$DescriptionSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='PharmacotherapeuticGroup'] and $PharmacotherapeuticGroupShow">
              <li>
                <a href="#PharmacotherapeuticGroupSection">
                  <xsl:value-of select="$PharmacotherapeuticGroupSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='PharmacoDynamics'] and $PharmacoDynamicsShow">
              <li>
                <a href="#PharmacoDynamicsSection">
                  <xsl:value-of select="$PharmacoDynamicsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='PharmacoKinetics'] and $PharmacoKineticsShow">
              <li>
                <a href="#PharmacoKineticsSection">
                  <xsl:value-of select="$PharmacoKineticsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Indications'] and $IndicationsShow">
              <li>
                <a href="#IndicationsSection">
                  <xsl:value-of select="$IndicationsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='CounterIndications'] and $CounterIndicationsShow">
              <li>
                <a href="#CounterIndicationsSection">
                  <xsl:value-of select="$CounterIndicationsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='WithCare'] and $WithCareShow">
              <li>
                <a href="#WithCareSection">
                  <xsl:value-of select="$WithCareSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='PregnancyAndLactation'] and $PregnancyAndLactationShow">
              <li>
                <a href="#PregnancyAndLactationSection">
                  <xsl:value-of select="$PregnancyAndLactationSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='DosingAndAdministration'] and $DosingAndAdministrationShow">
              <li>
                <a href="#DosingAndAdministrationSection">
                  <xsl:value-of select="$DosingAndAdministrationSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='SideEffects'] and $SideEffectsShow">
              <li>
                <a href="#SideEffectsSection">
                  <xsl:value-of select="$SideEffectsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Overdose'] and $OverdoseShow">
              <li>
                <a href="#OverdoseSection">
                  <xsl:value-of select="$OverdoseSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Interaction'] and $InteractionShow">
              <li>
                <a href="#InteractionSection">
                  <xsl:value-of select="$InteractionSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='SpecialInstructions'] and $SpecialInstructionsShow">
              <li>
                <a href="#SpecialInstructionsSection">
                  <xsl:value-of select="$SpecialInstructionsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='MachineryOperation'] and $MachineryOperationShow">
              <li>
                <a href="#MachineryOperationSection">
                  <xsl:value-of select="$MachineryOperationSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='FormDosage'] and $FormDosageShow">
              <li>
                <a href="#FormDosageSection">
                  <xsl:value-of select="$FormDosageSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Package'] and $PackageShow">
              <li>
                <a href="#PackageSection">
                  <xsl:value-of select="$PackageSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='StorageConditions'] and $StorageConditionsShow">
              <li>
                <a href="#StorageConditionsSection">
                  <xsl:value-of select="$StorageConditionsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='ShelfLife'] and $ShelfLifeShow">
              <li>
                <a href="#ShelfLifeSection">
                  <xsl:value-of select="$ShelfLifeSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='ConditionsOfSupply'] and $ConditionsOfSupplyShow">
              <li>
                <a href="#ConditionsOfSupplySection">
                  <xsl:value-of select="$ConditionsOfSupplySectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='RegistrationCertificateOwner'] and $RegistrationCertificateOwnerShow">
              <li>
                <a href="#RegistrationCertificateOwnerSection">
                  <xsl:value-of select="$RegistrationCertificateOwnerSectionName" />
                </a>
              </li>
            </xsl:if>

          </ul>
        </div>

        <xsl:apply-templates select="TradeName" />
        <xsl:apply-templates select="Mnn" />

        <!-- to comment-->
        <xsl:apply-templates select="HtmlSection[@name='RegistrationNumber']" />
        <xsl:apply-templates select="RegistrationDate" />
        <xsl:apply-templates select="EndDate" />
        <xsl:apply-templates select="NullDate" />
        <xsl:apply-templates select="InformationRenewDate" />
        <xsl:apply-templates select="Synonyms" />
        <!-- /to comment-->

        <xsl:apply-templates select="HtmlSection[@name='DrugForm']" />
        <xsl:apply-templates select="Atc" />
        <xsl:apply-templates select="HtmlSection[@name='Composition']" />
        <xsl:apply-templates select="HtmlSection[@name='Description']" />
        <xsl:apply-templates select="HtmlSection[@name='PharmacotherapeuticGroup']" />
        <xsl:apply-templates select="HtmlSection[@name='PharmacoDynamics']" />
        <xsl:apply-templates select="HtmlSection[@name='PharmacoKinetics']" />
        <xsl:apply-templates select="HtmlSection[@name='Indications']" />
        <xsl:apply-templates select="HtmlSection[@name='CounterIndications']" />
        <xsl:apply-templates select="HtmlSection[@name='WithCare']" />
        <xsl:apply-templates select="HtmlSection[@name='PregnancyAndLactation']" />
        <xsl:apply-templates select="HtmlSection[@name='DosingAndAdministration']" />
        <xsl:apply-templates select="HtmlSection[@name='SideEffects']" />
        <xsl:apply-templates select="HtmlSection[@name='Overdose']" />
        <xsl:apply-templates select="HtmlSection[@name='Interaction']" />
        <xsl:apply-templates select="HtmlSection[@name='SpecialInstructions']" />
        <xsl:apply-templates select="HtmlSection[@name='MachineryOperation']" />
        <xsl:apply-templates select="HtmlSection[@name='FormDosage']" />

        <!-- to comment-->
        <xsl:apply-templates select="HtmlSection[@name='Package']" />
        <xsl:apply-templates select="HtmlSection[@name='StorageConditions']" />
        <xsl:apply-templates select="HtmlSection[@name='ShelfLife']" />
        <xsl:apply-templates select="HtmlSection[@name='ConditionsOfSupply']" />
        <!-- /to comment-->


        <xsl:apply-templates select="Manufacturers" />
        <xsl:apply-templates select="Representatives" />

        <!-- to comment-->
        <xsl:apply-templates select="HtmlSection[@name='RegistrationCertificateOwner']" />
        <!-- /to comment-->

        <div style="height: 60px;"></div>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="DietarySupplement">
    <html>
      <xsl:call-template name="Header" />
      <body>

        <div class="HeaderContainer">
          <ul>
            <xsl:if test="TradeName and $TradeNameShow">
              <li>
                <a href="#TradeNameSection">
                  <xsl:value-of select="$TradeNameSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="Mnn and $MnnShow">
              <li>
                <a href="#MnnSection">
                  <xsl:value-of select="$MnnSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='RegistrationNumber'] and $RegistrationNumberShow">
              <li>
                <a href="#RegistrationNumberSection">
                  <xsl:value-of select="$RegistrationNumberSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="RegistrationDate and $RegistrationDateShow">
              <li>
                <a href="#RegistrationDateSection">
                  <xsl:value-of select="$RegistrationDateSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="NullDate and $NullDateShow">
              <li>
                <a href="#NullDateSection">
                  <xsl:value-of select="$NullDateSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="InformationRenewDate and $InformationRenewDateShow">
              <li>
                <a href="#InformationRenewDateSection">
                  <xsl:value-of select="$InformationRenewDateSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="Manufacturers and $ManufacturersShow">
              <li>
                <a href="#ManufacturersSection">
                  <xsl:value-of select="$ManufacturersSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='DrugForm'] and $DrugFormShow">
              <li>
                <a href="#DrugFormSection">
                  <xsl:value-of select="$DrugFormSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Composition'] and $CompositionShow">
              <li>
                <a href="#CompositionSection">
                  <xsl:value-of select="$CompositionSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Overdose'] and $OverdoseShow">
              <li>
                <a href="#OverdoseSection">
                  <xsl:value-of select="$OverdoseSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='SpecialInstructions'] and $SpecialInstructionsShow">
              <li>
                <a href="#SpecialInstructionsSection">
                  <xsl:value-of select="$SpecialInstructionsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='StorageConditions'] and $StorageConditionsShow">
              <li>
                <a href="#StorageConditionsSection">
                  <xsl:value-of select="$StorageConditionsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='ShelfLife'] and $ShelfLifeShow">
              <li>
                <a href="#ShelfLifeSection">
                  <xsl:value-of select="$ShelfLifeSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='RegistrationCertificateOwner'] and $RegistrationCertificateOwnerShow">
              <li>
                <a href="#RegistrationCertificateOwnerSection">
                  <xsl:value-of select="$RegistrationCertificateOwnerSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='UsageArea'] and $UsageAreaShow">
              <li>
                <a href="#UsageAreaSection">
                  <xsl:value-of select="$UsageAreaSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='Recommendations'] and $RecommendationsShow">
              <li>
                <a href="#RecommendationsSection">
                  <xsl:value-of select="$RecommendationsSectionName" />
                </a>
              </li>
            </xsl:if>

            <xsl:if test="HtmlSection[@name='ResearchProtocols'] and $ResearchProtocolsShow">
              <li>
                <a href="#ResearchProtocolsSection">
                  <xsl:value-of select="$ResearchProtocolsSectionName" />
                </a>
              </li>
            </xsl:if>
          </ul>
        </div>

        <xsl:apply-templates select="InstructionName" />
        <xsl:apply-templates select="TradeName" />
        <xsl:apply-templates select="Mnn" />
        <xsl:apply-templates select="HtmlSection[@name='RegistrationNumber']" />
        <xsl:apply-templates select="RegistrationDate" />
        <xsl:apply-templates select="NullDate" />
        <xsl:apply-templates select="InformationRenewDate" />
        <xsl:apply-templates select="Manufacturers" />
        <xsl:apply-templates select="HtmlSection[@name='DrugForm']" />
        <xsl:apply-templates select="HtmlSection[@name='Composition']" />
        <xsl:apply-templates select="HtmlSection[@name='Overdose']" />
        <xsl:apply-templates select="HtmlSection[@name='SpecialInstructions']" />
        <xsl:apply-templates select="HtmlSection[@name='StorageConditions']" />
        <xsl:apply-templates select="HtmlSection[@name='ShelfLife']" />
        <xsl:apply-templates select="HtmlSection[@name='RegistrationCertificateOwner']" />

        <!--BAA Sections-->
        <xsl:apply-templates select="HtmlSection[@name='UsageArea']" />
        <xsl:apply-templates select="HtmlSection[@name='Recommendations']" />
        <xsl:apply-templates select="HtmlSection[@name='ResearchProtocols']" />
        <!-- /BAA Sections-->

        <div style="height: 60px;"></div>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="InstructionName">
    <xsl:if test="$InstructionNameShow">
      <div class="InstructionName">
        <xsl:value-of select="../InstructionName" />
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="TradeName[@locale='Ru']">
    <xsl:if test="$TradeNameShow">
      <div id="TradeNameSection" class="TradeNameSection">
        <strong>
          <xsl:value-of select="$TradeNameSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <xsl:value-of select="@value" />
        <xsl:if test="TradeName[@locale='En']">
          <xsl:text> </xsl:text>(<xsl:value-of select="../TradeName[@locale='En']/@value" />)
        </xsl:if>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Mnn">
    <xsl:if test="$MnnShow">
      <div id="MnnSection" class="Section">
        <strong>
          <xsl:value-of select="$MnnSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <xsl:value-of select="@value" />
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='RegistrationNumber']">
    <xsl:if test="$RegistrationNumberShow">
      <div id="RegistrationNumberSection" class="Section">
        <strong>
          <xsl:value-of select="$RegistrationNumberSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <xsl:value-of select="../HtmlSection[@name='RegistrationNumber']" disable-output-escaping="yes" />
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="RegistrationDate">
    <xsl:if test="$RegistrationDateShow">
      <div id="RegistrationDateSection" class="SectionHeader">
        <strong>
          <xsl:value-of select="$RegistrationDateSectionName" />:
        </strong>
      </div>
      <div class="DateSection">
        <xsl:for-each select="../RegistrationDate">
          <xsl:value-of select="@value" />
        </xsl:for-each>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="EndDate">
    <xsl:if test="$EndDateShow">
      <div id="EndDateSection" class="Section">
        <strong>
          <xsl:value-of select="$EndDateSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <xsl:value-of select="../EndDate/@value" />
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="NullDate">
    <xsl:if test="$NullDateShow">
      <div id="NullDateSection" class="Section">
        <strong>
          <xsl:value-of select="$NullDateSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <xsl:value-of select="../NullDate/@value" />
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="InformationRenewDate">
    <xsl:if test="$InformationRenewDateShow">
      <div id="InformationRenewDateSection" class="Section">
        <strong>
          <xsl:value-of select="$InformationRenewDateSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <xsl:value-of select="../InformationRenewDate/@value" />
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Synonyms">
    <xsl:if test="$SynonymsShow">
      <div id="SynonymsSection" class="SectionHeader">
        <strong>
          <xsl:value-of select="$SynonymsSectionName" />:
        </strong>
      </div>
      <div class="Synonyms">
        <xsl:for-each select="../Synonyms/Synonym">
          <div class="Synonym">
            <xsl:text> </xsl:text>
            <span class="SynonymEntry">
              <xsl:value-of select="@name" />
            </span>
            <xsl:text> </xsl:text>
            <span class="SynonymEntry">
              <xsl:value-of select="@drugForm" />
            </span>
            <xsl:text> </xsl:text>
            <span class="SynonymEntry">
              <xsl:value-of select="@drugUsage" />
            </span>
            <xsl:text> </xsl:text>
            <span class="SynonymEntry">
              <xsl:value-of select="@manufacturer" />
            </span>
            <xsl:text> </xsl:text>
            <span class="SynonymEntry">
              <xsl:value-of select="@country" />
            </span>
          </div>
        </xsl:for-each>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='DrugForm']">
    <xsl:if test="$DrugFormShow">
      <div id="DrugFormSection" class="Section">
        <strong>
          <xsl:value-of select="$DrugFormSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <xsl:value-of select="../HtmlSection[@name='DrugForm']" disable-output-escaping="yes" />
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Atc">
    <xsl:if test="$AtcShow">
      <div id="AtcSection" class="SectionHeader">
        <strong>
          <xsl:value-of select="$AtcSectionName" />:
        </strong>
      </div>
      <xsl:for-each select="../Atc/AtcRow">
        <div>
          <xsl:text> </xsl:text>
          <span class="AtcEntry">
            <xsl:value-of select="@code" />
          </span>
          <xsl:text> </xsl:text>
          <span class="AtcEntry">
            <xsl:value-of select="@name" />
          </span>
        </div>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='Composition']">
    <xsl:if test="$CompositionShow">
      <div id="CompositionSection" class="Section">
        <strong>
          <xsl:value-of select="$CompositionSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="CompositionContent">
          <xsl:value-of select="../HtmlSection[@name='Composition']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='Description']">
    <xsl:if test="$DescriptionShow">
      <div id="DescriptionSection" class="Section">
        <strong>
          <xsl:value-of select="$DescriptionSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='Description']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='PharmacotherapeuticGroup']">
    <xsl:if test="$PharmacotherapeuticGroupShow">
      <div id="PharmacotherapeuticGroupSection" class="Section">
        <strong>
          <xsl:value-of select="$PharmacotherapeuticGroupSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='PharmacotherapeuticGroup']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='PharmacoDynamics']">
    <xsl:if test="$PharmacoDynamicsShow">
      <div id="PharmacoDynamicsSection" class="Section">
        <strong>
          <xsl:value-of select="$PharmacoDynamicsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='PharmacoDynamics']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='PharmacoKinetics']">
    <xsl:if test="$PharmacoKineticsShow">
      <div id="PharmacoKineticsSection" class="Section">
        <strong>
          <xsl:value-of select="$PharmacoKineticsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='PharmacoKinetics']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='Indications']">
    <xsl:if test="$IndicationsShow">
      <div id="IndicationsSection" class="Section">
        <strong>
          <xsl:value-of select="$IndicationsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='Indications']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='CounterIndications']">
    <xsl:if test="$CounterIndicationsShow">
      <div id="CounterIndicationsSection" class="Section">
        <strong>
          <xsl:value-of select="$CounterIndicationsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='CounterIndications']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='WithCare']">
    <xsl:if test="$WithCareShow">
      <div id="WithCareSection" class="Section">
        <strong>
          <xsl:value-of select="$WithCareSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='WithCare']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='PregnancyAndLactation']">
    <xsl:if test="$PregnancyAndLactationShow">
      <div id="PregnancyAndLactationSection" class="Section">
        <strong>
          <xsl:value-of select="$PregnancyAndLactationSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='PregnancyAndLactation']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='DosingAndAdministration']">
    <xsl:if test="$DosingAndAdministrationShow">
      <div id="DosingAndAdministrationSection" class="Section">
        <strong>
          <xsl:value-of select="$DosingAndAdministrationSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='DosingAndAdministration']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='SideEffects']">
    <xsl:if test="$SideEffectsShow">
      <div id="SideEffectsSection" class="Section">
        <strong>
          <xsl:value-of select="$SideEffectsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='SideEffects']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='Overdose']">
    <xsl:if test="$OverdoseShow">
      <div id="OverdoseSection" class="Section">
        <strong>
          <xsl:value-of select="$OverdoseSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='Overdose']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='Interaction']">
    <xsl:if test="$InteractionShow">
      <div id="InteractionSection" class="Section">
        <strong>
          <xsl:value-of select="$InteractionSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='Interaction']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='SpecialInstructions']">
    <xsl:if test="$SpecialInstructionsShow">
      <div id="SpecialInstructionsSection" class="Section">
        <strong>
          <xsl:value-of select="$SpecialInstructionsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='SpecialInstructions']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='MachineryOperation']">
    <xsl:if test="$MachineryOperationShow">
      <div id="MachineryOperationSection" class="Section">
        <strong>
          <xsl:value-of select="$MachineryOperationSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='MachineryOperation']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='FormDosage']">
    <xsl:if test="$FormDosageShow">
      <div id="FormDosageSection" class="Section">
        <strong>
          <xsl:value-of select="$FormDosageSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='FormDosage']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='Package']">
    <xsl:if test="$PackageShow">
      <div id="PackageSection" class="Section">
        <strong>
          <xsl:value-of select="$PackageSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='Package']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='StorageConditions']">
    <xsl:if test="$StorageConditionsShow">
      <div id="StorageConditionsSection" class="Section">
        <strong>
          <xsl:value-of select="$StorageConditionsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='StorageConditions']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='ShelfLife']">
    <xsl:if test="$ShelfLifeShow">
      <div id="ShelfLifeSection" class="Section">
        <strong>
          <xsl:value-of select="$ShelfLifeSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='ShelfLife']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='ConditionsOfSupply']">
    <xsl:if test="$ConditionsOfSupplyShow">
      <div id="ConditionsOfSupplySection" class="Section">
        <strong>
          <xsl:value-of select="$ConditionsOfSupplySectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='ConditionsOfSupply']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Manufacturers">
    <xsl:if test="$ManufacturersShow">
      <div id="ManufacturersSection" class="Section">
        <strong>
          <xsl:value-of select="$ManufacturersSectionName" />:
        </strong>
      </div>
      <xsl:for-each select="../Manufacturers/Manufacturer">
        <div>
          <xsl:text> </xsl:text>
          <span class="ManufacturerEntry">
            <xsl:value-of select="@name" />
          </span>
          <xsl:text> </xsl:text>
          <span class="ManufacturerEntry">
            <xsl:value-of select="@country" />
          </span>
        </div>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Representatives">
    <xsl:if test="$RepresentativesShow">
      <div id="RepresentativesSection" class="Section">
        <strong>
          <xsl:value-of select="$RepresentativesSectionName" />:
        </strong>
      </div>
      <xsl:for-each select="../Representatives/Representative">
        <div>
          <xsl:text> </xsl:text>
          <span class="RepresentativerEntry">
            <xsl:value-of select="@name" />
          </span>
          <xsl:text> </xsl:text>
          <span class="RepresentativeEntry">
            <xsl:value-of select="@country" />
          </span>
        </div>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='RegistrationCertificateOwner']">
    <xsl:if test="$RegistrationCertificateOwnerShow">
      <div id="RegistrationCertificateOwnerSection" class="Section">
        <strong>
          <xsl:value-of select="$RegistrationCertificateOwnerSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='RegistrationCertificateOwner']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <!--BAA Sections-->
  <xsl:template match="HtmlSection[@name='UsageArea']">
    <xsl:if test="$UsageAreaShow">
      <div id="UsageAreaSection" class="Section">
        <strong>
          <xsl:value-of select="$UsageAreaSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='UsageArea']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='Recommendations']">
    <xsl:if test="$RecommendationsShow">
      <div id="RecommendationsSection" class="Section">
        <strong>
          <xsl:value-of select="$RecommendationsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='Recommendations']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="HtmlSection[@name='ResearchProtocols']">
    <xsl:if test="$ResearchProtocolsShow">
      <div id="ResearchProtocolsSection" class="Section">
        <strong>
          <xsl:value-of select="$ResearchProtocolsSectionName" />:
        </strong>
        <xsl:text> </xsl:text>
        <span class="HtmlContent">
          <xsl:value-of select="../HtmlSection[@name='ResearchProtocols']" disable-output-escaping="yes" />
        </span>
      </div>
    </xsl:if>
  </xsl:template>
  <!-- /BAA Sections-->

</xsl:stylesheet>