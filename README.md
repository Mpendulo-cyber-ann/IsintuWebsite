# Isintu Traditional Attire Website

An ASP.NET MVC 5 site for browsing, buying and hiring traditional South African
attire, backed by MySQL through Entity Framework 6.

## How to set this up in Visual Studio

1. **Create the project shell.**
   File > New Project > ASP.NET Web Application (.NET Framework) > MVC.
   Name it `IsintuWebsite` so the namespaces below line up without any changes.

2. **Install NuGet packages** (Tools > NuGet Package Manager > Package Manager Console):
   ```
   Install-Package EntityFramework -Version 6.4.4
   Install-Package MySql.Data.Entity -Version 8.0.33
   Install-Package MySql.Data -Version 8.0.33
   ```

3. **Copy in the project files.**
   Copy the `Models`, `Controllers`, `Views`, `Content`, `Migrations` and
   `Images` folders from this package into your new project, overwriting the
   default `HomeController.cs` and default views Visual Studio generated.

4. **Add the connection string.**
   Open `Web.config.snippet` in this package and copy both blocks into your
   real `Web.config`, inside the `<configuration>` tag. Update the MySQL
   server, database name, username and password to match your own setup.

5. **Create the database.**
   In MySQL, run:
   ```sql
   CREATE DATABASE IsintuDB;
   ```

6. **Enable migrations and seed the data.**
   In Package Manager Console:
   ```
   Enable-Migrations
   Update-Database
   ```
   This creates all the tables and loads the sample Zulu attire items with the
   buy price (R5,400) and rental price (R340/day) already set.

7. **Add your images.**
   Drop your attire photos into the `Images` folder using the filenames
   already referenced in `Migrations/Configuration.cs` (e.g.
   `zulu-attire-main.jpg`, `zulu-isicholo.jpg`, `zulu-beaded-necklace.jpg`,
   `zulu-womens-dress.jpg`, `zulu-shield-spear.jpg`), or update the `ImageUrl`
   values in `Configuration.cs` to match whatever filenames you use.

8. **Run the project** (F5). You should land on the home page, be able to
   click through to Shop Attire, filter by category, open an item, choose
   Buy or Rent, fill in your details, and place an order.

## How the pricing works

All the price maths lives on the model classes, not in the controller or the
view, so it's easy to follow and to unit test:

- `ClothingItem.GetUnitPrice(orderType, rentalDays)` - works out what a single
  unit costs depending on whether it's being bought outright or rented for a
  number of days.
- `OrderItem.CalculateItemTotal()` - multiplies that unit price by quantity,
  and adds the optional R150 per-item accessory fee if the customer ticked
  that box.
- `Order.CalculateOrderTotal()` - uses LINQ's `Sum()` to add up every item on
  the order, so the grand total always reflects whatever is currently in the
  order rather than a number stored somewhere else.
- `Hire.CalculateLateFee()` - works out a late fee if a rented item comes back
  after its agreed return date.

## Notes

- Controllers pass data to views only through strongly typed models and view
  models (`OrderFormViewModel`, `OrderConfirmationViewModel`) - there's no
  `ViewBag` anywhere in the controllers.
- The order form on the Details page includes the dropdown (Buy/Rent),
  quantity and rental-days textboxes, the accessories checkbox, and the
  submit button, exactly as laid out in the project brief.
