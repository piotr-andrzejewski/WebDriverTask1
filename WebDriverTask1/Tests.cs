using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace WebDriverTask1
{
    public class Tests
    {
        private readonly IWebDriver driver;
        private const string baseUrl = "https://pastebin.com/";
        private const string content = "Hello from WebDriver";
        private const string title = "helloweb";

        public Tests()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("-inprivate");
            options.AddArgument("--start-maximized");
            driver = new EdgeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Fact]
        public void CreateNewPasteTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Accept cookies
            driver
                .FindElement(By.CssSelector("#qc-cmp2-ui > div.qc-cmp2-footer.qc-cmp2-footer-overlay.qc-cmp2-footer-scrolled > div > button.css-47sehv"))
                .Click();

            // Enter the code into the "New Paste" text area
            IWebElement pasteCodeElement = driver.FindElement(By.Id("postform-text"));
            pasteCodeElement.SendKeys(content);

            // Set the "Paste Expiration" dropdown to "10 Minutes"
            driver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            driver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            // Set the "Paste Name / Title" to "helloweb"
            IWebElement pasteNameElement = driver.FindElement(By.Id("postform-name"));
            pasteNameElement.SendKeys(title);

            // Click the "Create New Paste" button
            IWebElement createPasteButton = driver.FindElement(By.XPath("//button[contains(text(),'Create New Paste')]"));
            createPasteButton.Click();

            // Verify that the paste name is correct
            IWebElement pasteTitle = driver.FindElement(By.XPath("//div[@class='info-top']//h1"));
            Assert.Equal(title, pasteTitle.Text);

            // Verify that expiration time is correct
            IWebElement expirationTime = driver.FindElement(By.XPath("//div[@class='expire']"));
            Assert.Equal("10 min", expirationTime.Text, StringComparer.OrdinalIgnoreCase);

            // Verify that the content is correct
            IWebElement pasteContent = driver.FindElement(By.XPath("//div[@class='de1']"));
            Assert.Equal(content, pasteContent.Text);

            driver.Close();
        }
    }
}