using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementLab.Drugscreening.Contracts
{
    /// <summary>
    /// Измеряемое значение чего-либо
    /// </summary>
    /// <summary lang="en">
    /// Defines a single or set of UnitMeasurements such as 25mg or 25mg/2kg/hour.
    /// </summary>
    public class Measurement : List<UnitMeasurement>
    {
    }
}