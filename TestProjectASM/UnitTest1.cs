using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectASM
{
    [TestFixture]
    public class UserControllerTests
    {
        private IWebDriver driver;
        private const string BaseUrl = "http://localhost:5184/"; // Update with your base URL
        

        [SetUp]
        public void Setup()
        {
            // Initialize WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up WebDriver
            driver.Quit();
        }

        [Test]
        public void Test_Logo_Displayed_Correctly()
        {
            // Navigate to the homepage
            driver.Navigate().GoToUrl(BaseUrl);

            // Find the logo element
            IWebElement logoElement = driver.FindElement(By.Id("BTECLogo")); // Update with your logo selector

            // Verify that the logo element is displayed
            Assert.IsTrue(logoElement.Displayed, "Logo is not displayed on the page");
        }
        [Test]
        public void Test_Login_With_Valid_Credentials()
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl($"{BaseUrl}Auth/Login");

            // Find the login form elements
            IWebElement emailInput = driver.FindElement(By.Id("email")); // Update with your email input ID
            IWebElement passwordInput = driver.FindElement(By.Id("password")); // Update with your password input ID
            IWebElement submitButton = driver.FindElement(By.Id("submit")); // Update with your submit button ID

            // Enter valid credentials
            emailInput.SendKeys("admin@example.com"); // Replace with a valid username
            passwordInput.SendKeys("adminpassword"); // Replace with a valid password

            // Submit the form
            submitButton.Click();

            // Wait for the page to load (you might need to adjust the wait time)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Verify that the user is redirected to the dashboard or some other authenticated page
            Assert.AreEqual($"{BaseUrl}", driver.Url);
        }
    }
}