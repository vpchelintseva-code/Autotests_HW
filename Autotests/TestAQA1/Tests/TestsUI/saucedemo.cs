
using static Microsoft.Playwright.Assertions;
using Microsoft.Playwright;

public class SouceDemo : BaseTest
{
    [Test]// успешный логин на saucedemo.com
    public async Task SucsessfullyLoggedIn()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
        var userNameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username"});
        await userNameTextBox.FillAsync("standard_user");
        var passTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
        await passTextBox.FillAsync("secret_sauce");
        var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        await loginButton.ClickAsync();
        var productTitlleText = Page.GetByText("Products", new() { Exact = true });//проверить что есть видимость локатора (ищем по типу )
        await Microsoft.Playwright.Assertions.Expect(productTitlleText).ToBeVisibleAsync();

    }

    [Test] // авторизация с неверным паролем
    public async Task InvalidPassword()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
        var userNameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username"});
        await userNameTextBox.FillAsync("standard_user");
        var passTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
        await passTextBox.FillAsync("Test_sauce");
        var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        await loginButton.ClickAsync();
        var failMessageText = Page.Locator("//*[@id=\"login_button_container\"]");
        var failMessage = Page.GetByRole(AriaRole.Alert);
        await Microsoft.Playwright.Assertions.Expect(failMessage).ToBeVisibleAsync(); //ждем пока станет видно сообщзение
        await Microsoft.Playwright.Assertions.Expect(failMessage)
            .ToHaveTextAsync("Epic sadface: Username and password do not match any user in this service");// проверяется текст на сообщении
    }
    
    [Test] // проверка работы Dropdown для Dynamic Catalog в боковом меню
    public async Task DropdownOfDynamicCatalogInSidebar()
    {
        //авторизация 
        await Page.GotoAsync("https://www.saucedemo.com/");
        var userNameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username"});
        await userNameTextBox.FillAsync("standard_user");
        var passTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
        await passTextBox.FillAsync("secret_sauce");
        var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        await loginButton.ClickAsync();
        var productTitlleText = Page.GetByText("Products", new() { Exact = true });//проверить что есть видимость локатора (ищем по типу )
        await Microsoft.Playwright.Assertions.Expect(productTitlleText).ToBeVisibleAsync();
        
        //раскрытие бокового меню и проверка 
        var menu = Page.Locator("#react-burger-menu-btn");//ищем кнопку бокового меню
        await menu.ClickAsync();// кликнуть меню для раскрытия
        
        
        var sideMenu = Page.Locator(".bm-menu-wrap"); //тут ищемэллемент с классом bm-menu-wrap поэтому "." 
        await Expect(sideMenu).ToHaveAttributeAsync("aria-hidden", "false"); //проверка атрибута что меню рассскрыто
        await Expect(sideMenu).ToBeVisibleAsync(); // проверяем что оно видимо
        
        var dynamicCatalogButton = Page.GetByRole(AriaRole.Button, new () { Name = "Dynamic Catalog", Exact = true });
        await Microsoft.Playwright.Assertions.Expect(dynamicCatalogButton).ToBeVisibleAsync();
        await Microsoft.Playwright.Assertions.Expect(dynamicCatalogButton)
            .ToHaveAttributeAsync("aria-expanded", "false");//проверяем что исходное состояние каталога скрыто
        var chevron = dynamicCatalogButton.Locator(".submenu-chevron"); //проверка 
        await dynamicCatalogButton.ClickAsync();
        await Expect(chevron).ToHaveClassAsync("submenu-chevron open");
        await Microsoft.Playwright.Assertions.Expect(dynamicCatalogButton)
            .ToHaveAttributeAsync("aria-expanded", "true");//проверяем что после клика  каталог раскрылся
        var submenu = sideMenu.Locator("#dynamic_catalog_submenu"); // есть локатор саб-меню
        await Expect(submenu).ToBeVisibleAsync(); //саб меню видимо пользователю
        
        //проверяем что в сабменю
        await Expect(submenu.Locator(":scope > a")).ToHaveCountAsync(3); //ищем что лежит в саб-меню (a используем так как все дети у сабменю - всех трёх тег "a#dynamic_catalog_" )
        await Expect(submenu.Locator("#dynamic_catalog_lazy_load_link")).ToBeVisibleAsync();
        await Expect(submenu.Locator("#dynamic_catalog_spinner_link")).ToBeVisibleAsync();
        await Expect(submenu.Locator("#dynamic_catalog_slider_link")).ToBeVisibleAsync();
        
    }
}


