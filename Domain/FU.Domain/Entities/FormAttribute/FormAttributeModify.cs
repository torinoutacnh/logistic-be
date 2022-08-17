using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.FormAttribute
{
    public class FormAttributeModify
    {
        public ControlType ControlType { get; private set; }
        public DataType DataType { get; private set; }
        public ICollection<string>? DropDownValues { get; private set; }

        private FormAttributeModify() { }

        public FormAttributeModify(ControlType controlType,DataType dataType, string[]? dropdown = null)
        {
            if ((controlType == ControlType.SelectBox
                || controlType == ControlType.CheckBox
                || controlType == ControlType.Radio)
                && (dropdown == null || dropdown.Length == 0))
                throw new ArgumentException($"{nameof(dropdown)} cannot be null when {nameof(controlType)} is select box, radio, check box!");

            ControlType = controlType;
            DataType = dataType;
            DropDownValues = dropdown;
        }

        public FormAttributeModify Update(ControlType? controlType = null, DataType? dataType = null, string[]? dropdown = null)
        {
            if ((controlType == ControlType.SelectBox
                || controlType == ControlType.CheckBox
                || controlType == ControlType.Radio)
                && (dropdown == null || dropdown.Length == 0))
                throw new ArgumentException($"{nameof(dropdown)} cannot be null when {nameof(controlType)} is select box, radio, check box!");

            ControlType = controlType == null? ControlType : controlType.Value;
            DataType = dataType == null ? DataType : dataType.Value;
            DropDownValues = dropdown ?? DropDownValues;
            return this;
        }
    }
}
