using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace RozetkaTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By phoneCategory = By.XPath("//aside[contains(@class,'sidebar')]//a[contains(@href,'telefony')]");
        private readonly By smartPhone = By.CssSelector("[title~=Мобільні] img");
        private readonly By appleProducer = By.XPath("//a[contains(@href,'producer=apple')]/parent::li");
        private readonly By sortFromExpensiveToCheap = By.CssSelector("option[value~=expensive]");

        private readonly By categoryDropDownButton = By.XPath("//button[@id='fat-menu']");
        private readonly By tvCategory = By.XPath("//ul[contains(@class,'menu-categories')]//a[contains(@href,'telefony')]/span");
        private readonly By tvCategoryButton = By.CssSelector("[title~=Телевізори] img");
        private readonly By samsungProducer = By.XPath("//li/a[contains(@href,'producer=samsung')]");

        private readonly By goodsForGamersCategory = By.XPath("//ul[contains(@class,'menu-categories')]//a[contains(@href,'game')]/span");
        private readonly By gameConsolesCategory = By.CssSelector("[title~=приставки] img");
        private readonly By microsoftProducer = By.XPath("//label[@for='Microsoft']");

        private readonly By addToCartButton = By.XPath("//button[contains(@class,'buy-button')]/ancestor::app-buy-button");
        private readonly By cartButton = By.XPath("//button[contains(@class,'header__button--active')]");

        private readonly By counterOfItemsInCart = By.XPath("//span[contains(@class,'counter')]");
        private readonly By totalAmountInCart = By.CssSelector("div.cart-receipt__sum");

        private const string expectedCountOfItemsInCart = "3";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://rozetka.com.ua/ua/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var phoneCategorySelect = driver.FindElement(phoneCategory);
            phoneCategorySelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var smartPhoneSelect = driver.FindElement(smartPhone);
            smartPhoneSelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var appleProducerSelect = driver.FindElement(appleProducer);
            appleProducerSelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var sortPhonesSelect = driver.FindElement(sortFromExpensiveToCheap);
            sortPhonesSelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var addPhoneToCartButtonClick= driver.FindElement(addToCartButton);
            addPhoneToCartButtonClick.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var categoryDropDownButtonClick = driver.FindElement(categoryDropDownButton);
            categoryDropDownButtonClick.Click();
            var tvCategorySelect = driver.FindElement(tvCategory);
            tvCategorySelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var tvCategoryClick = driver.FindElement(tvCategoryButton);
            tvCategoryClick.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var samsungProducerSelect = driver.FindElement(samsungProducer);
            samsungProducerSelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var sortTvSelect = driver.FindElement(sortFromExpensiveToCheap);
            sortTvSelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var addTvToCartButtonClick = driver.FindElement(addToCartButton);
            addTvToCartButtonClick.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var categoryButtonClick = driver.FindElement(categoryDropDownButton);
            categoryButtonClick.Click();
            var goodsForGamersCategorySelect = driver.FindElement(goodsForGamersCategory);
            goodsForGamersCategorySelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var gameConsolesCategorySelect = driver.FindElement(gameConsolesCategory);
            gameConsolesCategorySelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var microsoftProducerSelect = driver.FindElement(microsoftProducer);
            microsoftProducerSelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var sortGameConsolesSelect = driver.FindElement(sortFromExpensiveToCheap);
            sortGameConsolesSelect.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var addConsoleToCartButtonClick = driver.FindElement(addToCartButton);
            addConsoleToCartButtonClick.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var actualQttOfItemsInCart = driver.FindElement(counterOfItemsInCart).Text;
            Assert.AreEqual(expectedCountOfItemsInCart, actualQttOfItemsInCart, "not enough items");

            var CartbuttonClick = driver.FindElement(cartButton);
            CartbuttonClick.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var amountInCart = driver.FindElement(totalAmountInCart).Text;
            int.TryParse(string.Join("", amountInCart.Where(c => char.IsDigit(c))), out int sumInCart);
            bool compareAmountInCart = (sumInCart/27) < 5000;
            Assert.IsTrue(compareAmountInCart);

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
