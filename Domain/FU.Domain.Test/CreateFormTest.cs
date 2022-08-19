using FU.Domain.Base;
using FU.Domain.Entities.Form;
using FU.Domain.Entities.FormAttribute;
using Moq;
using System;

namespace FU.Domain.Test
{
    [TestClass]
    public class CreateFormTest
    {
        [TestMethod]
        public void CreateFormInfo_WithValidInput_ReturnTrue()
        {
            // Arrange
            string name = "name";
            string code = "code";
            string number = "number";
            FormInfo info = null;
            Func<FormInfo> func = () => info = new(name, code, number);

            // Act
            func();

            // Assert
            Assert.IsNotNull(info);
            Assert.IsInstanceOfType(info, typeof(FormInfo));
        }

        [TestMethod]
        public void CreateFormInfo_WithInValidInput_ReturnTrue()
        {
            // Arrange
            string name = "name";
            string code = null;
            string number = "number";
            Func<FormInfo> func = () => new(name, code, number);

            // Act

            // Assert
            Assert.ThrowsException<ArgumentNullException>(func);
        }

        [TestMethod]
        public void CreateForm_WithValidInput_ReturnTrue()
        {
            // Arrange
            FormInfo info = new("name", "code", "number");
            FormAttributeEntity[] attrs = Array.Empty<FormAttributeEntity>();

            Func<FormEntity> func1 = () => new(info);
            Func<FormEntity> func2 = () => new(info, attrs);

            // Act
            FormEntity form1 = func1();
            FormEntity form2 = func2();

            // Assert
            Assert.IsNotNull(form1);
            Assert.IsNotNull(form2);
            Assert.IsInstanceOfType(form1, typeof(FormEntity));
            Assert.IsInstanceOfType(form1, typeof(FormEntity));
        }

        [TestMethod]
        public void CreateForm_WithInValidInput_ReturnTrue()
        {
            // Arrange
            FormInfo info = null;
            FormAttributeEntity[] attrs = null;

            Func<FormEntity> func1 = () => new(info);
            Func<FormEntity> func2 = () => new(info, attrs);

            // Act

            // Assert
            Assert.ThrowsException<ArgumentNullException>(func1);
            Assert.ThrowsException<ArgumentNullException>(func2);
        }
    }
}