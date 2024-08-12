using OpenQA.Selenium;

namespace WebDriverTask1
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        // Locators
        private readonly By newPasteTextArea = By.Id("postform-text");
        private readonly By pasteExpirationDropdown = By.XPath("//span[@id='select2-postform-expiration-container']");
        private readonly By pasteExpirationOption = By.XPath("//li[text()='10 Minutes']");
        private readonly By pasteNameInput = By.Id("postform-name");
        private readonly By createNewPasteButton = By.XPath("//button[contains(text(),'Create New Paste')]");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://pastebin.com/");
        }

        public void EnterPasteCode(string code)
        {
            driver.FindElement(newPasteTextArea).SendKeys(code);
        }

        public void SelectPasteExpiration(string expirationTime)
        {
            driver.FindElement(pasteExpirationDropdown).Click();
            driver.FindElement(pasteExpirationOption).Click();
        }

        public void EnterPasteName(string name)
        {
            driver.FindElement(pasteNameInput).SendKeys(name);
        }

        public void CreateNewPaste()
        {
            driver.FindElement(createNewPasteButton).Click();
        }
    }
}
