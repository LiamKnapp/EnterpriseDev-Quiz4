using System;
using System.Collections.Generic;

namespace Quiz4.Entities;

public partial class MeasurementPosition
{
    public string MeasurementPositionId { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Bpmeasurement> Bpmeasurements { get; set; } = new List<Bpmeasurement>();
}
