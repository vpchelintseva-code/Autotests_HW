using Microsoft.Playwright;


public class BaseTest
{
    protected IPage Page { get; private set; } = null!;
    protected PlaywrightFixture Fixture { get; private set; } = null!;

    [OneTimeSetUp]
    public async Task GlobalSetUp()
    {
        Fixture = new PlaywrightFixture();
        await Fixture.InitializeAsync();
    }

    [SetUp]
    public async Task SetUp()
    {
        Page = await Fixture.Browser.NewPageAsync(new BrowserNewPageOptions
        {
            ViewportSize = null
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.CloseAsync();
    }

    [OneTimeTearDown]
    public async Task GlobalTearDown()
    {
        await Fixture.DisposeAsync();
    }
}
