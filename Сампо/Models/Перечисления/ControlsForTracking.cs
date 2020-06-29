using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сампо.Models.Перечисления
{
    public enum ControlsForTracking
    {
        [Description("Не выбрано")]
        None,
        [Description("Дата и время начала сампо")]
        DateTimeSampo,
        [Description("Уровень ДнД")]
        JnJClass,
        [Description("Минимальное количество пар")]
        MinPair,
        [Description("Максимальное количество пар")]
        MaxPair,
        [Description("Как часто проходит само")]
        Period
    }
}
