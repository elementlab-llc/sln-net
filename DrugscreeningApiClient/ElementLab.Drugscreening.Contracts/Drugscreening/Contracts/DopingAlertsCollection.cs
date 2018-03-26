using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Коллекция предупреждений о возможных положительных результатах допинг-контроля.
    /// </summary>
    /// <summary lang="en">
    /// List of the results for doping alerts processing.
    /// </summary>
    
    public class DopingAlertsCollection : ResultsCollection<DopingAlert>
    {
    }
}