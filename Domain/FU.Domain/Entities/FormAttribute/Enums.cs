using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.FormAttribute
{
    public enum ControlType
    {
        TextInput = 0,
        NumberInput = 1,
        DatePicker = 2,
        TimePicker = 3,
        DateTimePicker = 4,
        Radio = 5,
        CheckBox = 6,
        SelectBox = 7,
    }

    public enum DataType
    {
        Text = 0,
        Number = 1,
        Email = 2,
        Date = 3,
        Time = 4,
        Datetime = 5,
    }

    public enum Position
    {
        Center = 0,
        TopCenter = 1,
        TopLeft = 2,
        TopRight = 3,
        BottomCenter = 4,
        BottomLeft = 5,
        BottomRight = 6,
        LeftCenter = 7,
        RightCenter = 8,
    }
}
