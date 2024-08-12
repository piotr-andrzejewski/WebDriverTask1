using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace WebDriverTask1
{
    public class Tests
    {
        private readonly IWebDriver driver;

        public Tests()
        {
            driver = new EdgeDriver();
        }

        [Fact]
        public void Should_Create_New_Paste_With_Specified_Attributes()
        {
            // Arrange
            var pastebinHomePage = new HomePage(driver);

            // Act
            pastebinHomePage.Open();
            pastebinHomePage.EnterPasteCode("Hello from WebDriver");
            pastebinHomePage.SelectPasteExpiration("10 Minutes");
            pastebinHomePage.EnterPasteName("helloweb");
            pastebinHomePage.CreateNewPaste();

            // Assert
            var createdPasteName = driver.FindElement(By.XPath("//div[@class='info-top']//h1")).Text;
            Assert.Equal("helloweb", createdPasteName);

            var expirationTime = driver.FindElement(By.XPath("//div[@class='expire']"));
            Assert.Equal("10 min", expirationTime.Text, StringComparer.OrdinalIgnoreCase);

            var createdPasteCode = driver.FindElement(By.XPath("//div[@class='de1']")).Text;
            Assert.Equal("Hello from WebDriver", createdPasteCode);

            driver.Close();
        }
    }
}