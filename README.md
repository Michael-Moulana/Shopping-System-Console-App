# C# Console Shopping System

Welcome to the Shopping System App! This console-based application provides a basic shopping system where you can manage customers, products, and dealers, and perform various actions related to buying products and tracking sales.
This project was developed as part of the **Advanced Programming** course during my bachelor's degree. The purpose of the project was to apply the concepts learned during the course to create a simple shopping system application.

## Table of Contents

- [Introduction](#introduction)
- [Usage](#usage)
- [Features](#features)
- [Getting Started](#getting-started)
- [Logic and Functionality](#logic-and-functionality)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Moulana Shopping System is a simple console application built in C# that allows you to manage a list of customers, products, and dealers. It provides a menu-driven interface for performing actions like adding/removing customers, products, and dealers, buying products, tracking sales, and more.

## Usage

1. Clone the repository or download the source code.
2. Open the solution in your preferred C# IDE.
3. Build and run the project.
4. Follow the on-screen instructions to navigate through the different options available in the system.

## Features

- Add, remove, and display customers, products, and dealers.
- Buy products by customers and track their purchases.
- Calculate and display the total purchases of a customer.
- Retrieve lists of customers who bought a specific product or from a specific dealer.
- Get the number of sales for a specific product.
- Retrieve a list of products purchased by a customer.
- Display a list of dealers and their total sales.
- Show a list of products, customers, and dealers.
- Exit the application.

## Getting Started

1. Clone the repository:
   ```bash
    https://github.com/Michael-Moulana/shopping-system-csharp-console.git
2. Open the solution in your C# IDE (e.g., Visual Studio).
3. Build and run the application.
4. Follow the menu prompts to interact with the shopping system.

## Logic and Functionality

The Moulana Shopping System is organized into classes to manage customers, products, dealers, and customer purchases. Here's an overview of the program's logic:

- **Main Program (`Program.cs`):** The main entry point of the application. It presents a menu to the user and handles the execution of different commands.

- **Customers (`Customer.cs`):** Defines the `Customer` class that represents customer information, including first name, last name, gender, code, ID, birth date, state, and city. Users can add and remove customers, and view the list of existing customers.

- **Dealers (`Dealer.cs`):** Defines the `Dealer` class that represents dealer information, including dealer name, establish year, economic code, owner's first name, owner's last name, state, and city. Users can add and remove dealers, and view the list of existing dealers.

- **Products (`Product.cs`):** Defines the `Product` class that represents product information, including name, code, brand, price, and weight. Users can add and remove products, and view the list of existing products.

- **CustomerProduct (`CustomerProduct.cs`):** Defines the `CustomerProduct` class that represents a purchase made by a customer. It contains references to the shop, customer, product, quantity, and purchase date.

- **ShoppingSystem (`ShoppingSystem.cs`):** Contains static lists to store customers, dealers, products, and customer purchases. It handles actions like buying products, tracking sales, and retrieving information related to customers, products, and dealers.

## Contributing

Contributions to this project are welcome! If you find any bugs or have suggestions for improvements, please feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. You can find the full license text in the [LICENSE](LICENSE) file.

