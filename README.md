```
md MyVault
cd MyVault
dotnet new classlib -o MyVault.Core
dotnet new mstest -o MyVault.Core.Tests
dotnet new sln
dotnet sln add ./MyVault.Core
dotnet sln add ./MyVault.Core.Tests
```

Abrir o MyVault.Core.csproj e alterar
```xml
<TargetFramework>netstandard2.0</TargetFramework>
```

```
cd MyVault.Core.Tests
dotnet add reference ../MyVault.Core
```

## Class Password

```csharp
using System;
using System.Text;

namespace MyVault.Core
{
    public static class Password
    {
        public static string Generate(
            int length = 8,
            bool includeSpecialChars = false,
            bool onlyUpperCase = false)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            const string special = "!@#$%ˆ&*(){}[];";
            var chars = includeSpecialChars ? (valid + special) : valid;

            var res = new StringBuilder();
            var rnd = new Random();

            while (0 < length--)
                res.Append(chars[rnd.Next(chars.Length)]);


            return onlyUpperCase ? res.ToString().ToUpper() : res.ToString();
        }
    }
}
```

### Testes de unidade

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyVault.Core.Tests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void ShouldGenerate8CharsLongPassword()
        {
            var password = MyVault.Core.Password.Generate();
            Assert.AreEqual(password.Length, 8);
        }
    }
}
```

```
cd MyVault.Core.Tests
dotnet test
```

### Blazor Wasm

```
dotnet new blazorwasm -o MyVault.Pwa --pwa
dotnet sln add ./MyVault.Pwa
cd MyVault.Pwa
dotnet add reference ../MyVault.Core
```

#### wwwroot
- mantem apenas o index, manifest e service worker

#### index
Altera o título, adiciona suporte ao CSS e fonte
```html
<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Poppins:wght@100;600&display=swap" rel="stylesheet">
<link href="css/app.css" rel="stylesheet" />
```

Copia a pasta CSS, images, icon-512, favicon do GIT para pasta wwwroot

Pasta Shared, deixa apenas o MainLayout.razor com o seguinte conteúdo:

```
@inherits LayoutComponentBase

<div class="page">
    <div class="container">
        @Body
    </div>
</div>
```

Desenvolver o Index.razor

Interoperar com JS

Instalar App e rodar

## Xamarin

Abrir com VS

Adicionar projeto Xamarin (Blank Forms App)

Adicionar referência ao Core

Custom Font
https://www.xamarinhelp.com/custom-fonts-xamarin-forms/

Image
https://docs.microsoft.com/pt-br/xamarin/get-started/tutorials/image/?tabs=vsmac&tutorial-step=3

Copy to Clipboard
https://docs.microsoft.com/pt-br/xamarin/essentials/clipboard
