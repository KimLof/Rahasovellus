# Money Management App

## Description

The Money Management App is a desktop application that allows users to manage their personal finances by uploading their bank statements as CSV files. The app enables users to categorize their income and expenses, making it easier to track their spending.

The functioning of the app is based on the CSV bank statement file, which contains information such as the amount, date, and payee. For example, transactions from HSL (Helsinki Regional Transport Authority) appear under names like `HSL MOBIILI` or `hsl mobiili`. These are keywords that the app uses to identify HSL transactions as travel expenses.

## Features

- Uploading bank statements in CSV format.
- Categorization of income and expenses.
- Ability to edit categories.
- Summary of income and expenses.

## Usage

After downloading the application, you need to extract it. In the `Release` folder, there is an executable file named `Money Management Counter`, which allows you to open the application.

### Basic Features

At the bottom left of the application, there are two buttons: `Add` and `New`. These buttons allow you to add CSV files to the application. By clicking `Add`, you can add a new CSV file, and you can have multiple CSV files loaded simultaneously. By clicking `New`, the application removes old CSV files from the registry and adds a new one.

To the right of these buttons are the `Income` and `Expenses` buttons. By clicking these, you can filter the view to show only income or expenses.

Once you have uploaded a CSV file, you can assign a category to it from the last column of the table on the left. The categories will appear in the table on the right. By clicking on a specific category in the left table, you will see only the expenses and/or income related to that category.

### Adding a Category

In the top left corner, there is a `Menu` dropdown menu, where you can find the `Edit Categories` button. Clicking this will take you to a new tab where you can edit, add, or delete categories.

In the `Categories` table on the left, you will see all the categories. Below it, you can add, edit, or delete categories. In the `Keywords` table on the right, you will see all the keywords for a specific category, which you can also add, delete, or edit.

## Support

If you need technical support or have any questions, please email kim@kimcode.fi or open an issue on GitHub.
