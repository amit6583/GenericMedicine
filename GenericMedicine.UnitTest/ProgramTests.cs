using NUnit.Framework;
using System;

namespace GenericMedicine.UnitTest
{
    [TestFixture]
    public class ProgramTests
    {
        private Program _program;

        [SetUp]
        public void SetUp()
        {
            _program = new Program();
        }

        // NUnit test cases for Create Medicine detail
        [Test]
        [TestCase("paracetamol", "cvf ", "carbon", "2021-03-10", 1)]
        public void ReturningMedicine(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            var result = _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip);

            Assert.That(result, Is.TypeOf<Medicine>());
        }

        [Test]
        [TestCase("paracetamol", null, "carbon", "2021-04-08", 1)]
        [TestCase("", "xhy", "carbon", "2021-04-08", 1)]
        public void MedicinenameEmpty_RaiseException(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
        }

        [Test]
        [TestCase("paracetamol", "xyz", "carbon", "2021-04-08", -3)]
        [TestCase("paracetamol", "xyz", "carbon", "2021-04-08", -1)]
        public void PriceisLessThan1_Exception(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
        }

        [Test]
        [TestCase("paracetamol", "xyz", "carbon", "2020-04-08", 1)]
        [TestCase("paracetamol", "xyz", "carbon", "2019-04-08", 1)]
        public void ExpiryDateLess_Exception(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
        }

        // NUnit test cases for Carton detail
        [Test]
        [TestCase(1, "2021-04-08", "xyz")]
        public void ReturningCartoonDetails(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            var medicine = new Medicine()
            {
                Name = "paracetamol",
                GenericMedicineName = "xyz",
                Composition = "carbon",
                ExpiryDate = new DateTime(2021, 5, 8),
                PricePerStrip = 1
            };

            var result = _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine);

            Assert.That(result, Is.TypeOf<CartonDetail>());
        }

        [Test]
        [TestCase(-2, "2021-04-08", "xyz")]
        [TestCase(-1, "2021-04-08", "xyz")]
        public void StrpCountLessThanOne_Exception(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            var medicine = new Medicine()
            {
                Name = "paracetamol",
                GenericMedicineName = "xyz",
                Composition = "Carbon",
                ExpiryDate = new DateTime(2021, 4, 7),
                PricePerStrip = 1
            };

            Assert.Throws<Exception>(() => _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
        }

        [Test]
        [TestCase(1, "2020-04-08", "xyz")]
        [TestCase(1, "2019-04-08", "xyz")]
        public void LaunchDateIsLess_Exception(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            var medicine = new Medicine()
            {
                Name = "paracetamol",
                GenericMedicineName = "xyz",
                Composition = "carbon",
                ExpiryDate = new DateTime(2022, 5, 8),
                PricePerStrip = 1
            };

            Assert.Throws<Exception>(() => _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
        }

        [Test]
        [TestCase(1, "2021-04-08", "abc", null)]
        public void IfMedicineIsNULL_Exception(int medicineStripCount, DateTime launchDate, string retailerAddress, Medicine medicine)
        {
            var result = _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine);

            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        [TestCase(21, "11/12/2022", "addrs1")]
        [TestCase(15, "11/12/2023", "addrs2")]
        [TestCase(53, "11/12/2024", "addrs3")]
        public void CartonObjectCreationTest(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            var medicine = new Medicine()
            {
                Name = "paracetamol",
                GenericMedicineName = "xyz",
                Composition = "carbon",
                ExpiryDate = new DateTime(2022, 5, 8),
                PricePerStrip = 1
            };

            Assert.Throws<Exception>(() => _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
        }
    }
}