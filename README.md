This package has been superseded by [CSharpFunctionalExtensions.UniTask](https://github.com/Razenpok/CSharpFunctionalExtensions.UniTask)
======================================================

Razensoft.Functional
======================================================

This library helps write code in more functional way. To get to know more about the principles behind it, check out the [Applying Functional Principles in C# Pluralsight course](https://enterprisecraftsmanship.com/ps-func).

## DISCLAIMER

Most of the code in this library is originating from the awesome [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions) project which you should definitely check out.

Differences between **Razensoft.Functional** (1.1.0) and **CSharpFunctionalExtensions** (v2.20.0):

- Removed all classes except `Result`, `UnitResult` and `Maybe`
- Renamed root namespace from `CSharpFunctionalExtensions` to `Razensoft.Functional`
- Added extensions methods for `UniTask`

## Installation

There are several ways to install this library into our project:

- **Plain install**: Clone or [download](https://github.com/Razenpok/Razensoft.Functional/archive/master.zip) this repository and put it somewhere in your Unity project
- **Unity Package Manager (UPM)**: Add the following line to *Packages/manifest.json*:
  - `"com.razensoft.functional": "https://github.com/Razenpok/Razensoft.Functional.git?path=src/Razensoft.Functional#1.1.0",`
- **[OpenUPM](https://openupm.com)**: After installing [openupm-cli](https://github.com/openupm/openupm-cli), run the following command:
  - `openupm add com.razensoft.functional`

## Get rid of primitive obsession

```csharp
Result<CustomerName> name = CustomerName.Create(model.Name);
Result<Email> email = Email.Create(model.PrimaryEmail);

Result result = Result.Combine(name, email);
if (result.IsFailure)
    return Error(result.Error);

var customer = new Customer(name.Value, email.Value);
```

## Make nulls explicit with the Maybe type

```csharp
Maybe<Customer> customerOrNothing = _customerRepository.GetById(id);
if (customerOrNothing.HasNoValue)
    return Error("Customer with such Id is not found: " + id);
```

## Compose multiple operations in a single chain

```csharp
return _customerRepository.GetById(id)
    .ToResult("Customer with such Id is not found: " + id)
    .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
    .Tap(customer => customer.Promote())
    .Tap(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
    .Finally(result => result.IsSuccess ? Ok() : Error(result.Error));
```

## Wrap multiple operations in a TransactionScope

```csharp
return _customerRepository.GetById(id)
    .ToResult("Customer with such Id is not found: " + id)
    .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
    .WithTransactionScope(customer => Result.Success(customer)
        .Tap(customer => customer.Promote())
        .Tap(customer => customer.ClearAppointments()))
    .Tap(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
    .Finally(result => result.IsSuccess ? Ok() : Error(result.Error));
```

## Readings and watchings

 * [Functional C#: Primitive obsession](http://enterprisecraftsmanship.com/2015/03/07/functional-c-primitive-obsession/)
 * [Functional C#: Non-nullable reference types](http://enterprisecraftsmanship.com/2015/03/13/functional-c-non-nullable-reference-types/)
 * [Functional C#: Handling failures, input errors](http://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/)
 * [Applying Functional Principles in C# Pluralsight course](https://enterprisecraftsmanship.com/ps-func)

## Contributors
A big thanks to the project author, [Vladimir Khorikov](https://github.com/vkhorikov), and to all of the contributors of the original project. Again, [don't forget to check it out](https://github.com/vkhorikov/CSharpFunctionalExtensions)!
