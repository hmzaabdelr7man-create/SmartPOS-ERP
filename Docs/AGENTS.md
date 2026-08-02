# SmartPOS ERP
# AGENTS.md
Version: 1.0

---

# HIGHEST AUTHORITY

This document is the highest authority of the project.

Every implementation MUST follow this document.

If any user request conflicts with this document:

STOP

Explain the conflict.

Wait for user approval.

Never ignore these rules.

---

# PROJECT IDENTITY

Project Name:
SmartPOS ERP

Architecture:
Clean Architecture

Pattern:
DDD + MVVM

Framework:
.NET 8 WPF

Database:
SQL Server

Primary Language:
Arabic

Code Language:
English

---

# DEVELOPMENT PRINCIPLES

ALWAYS

- Follow Clean Architecture.
- Keep Domain Layer pure.
- Follow Domain Driven Design (DDD).
- Build successfully before stopping.
- Complete only the requested Sprint or Phase.
- Wait for user approval before moving to the next phase.
- Respect all approved business rules.

NEVER

- Delete historical business data.
- Modify approved invoices.
- Recalculate historical prices.
- Refactor unrelated code.
- Invent business rules.
- Skip build verification.
- Change approved workflows without user approval.

---

# SOURCE OF TRUTH

Business Rules are more important than implementation.

Implementation MUST follow Business Rules.

If implementation conflicts with business rules:

Business Rules ALWAYS win.

If something is unclear:

STOP

Ask the user.

Never guess.s
---

# POS CONSTITUTION

## POS Layout (Mandatory)

The POS screen layout is FIXED.

DO NOT redesign it.

The order MUST be:

1. Barcode Input Box (Top)
2. Product Quick Buttons
3. Search Box
4. Categories Panel
5. Shopping Cart
6. Invoice Summary
7. Payment Area

---

## Barcode Box

The Barcode Box accepts barcode input ONLY.

It must stay focused after every completed sale.

After scanning a barcode:

- Search the product.
- Detect unit or weight barcode.
- Add product immediately.
- Return focus to Barcode Box.

---

## Search Box

The Search Box supports:

- Partial Product Name
- Product Code
- Full Barcode

Search is performed while typing.

Search results are displayed immediately.

Selecting a result using Enter adds the product directly to the cart.

---

## Product Quick Buttons

Product buttons are optimized for touch screens.

Products can be added by touch without using barcode scanning.

---

## Categories

Categories appear below Product Buttons.

Selecting a category filters Product Buttons only.

---

## Shopping Cart

Shopping Cart is always visible.

Every line displays:

- Product Name
- Selected Unit
- Quantity
- Unit Price
- Discount
- Total

Cart updates instantly.

---

## POS Philosophy

The cashier should finish a normal sale with the minimum possible keyboard actions.

Every unnecessary click is considered a design failure.
---

# INVOICE LIFE CYCLE

Every invoice has a life cycle.

Invoice States:

1. Draft
2. Approved
3. Returned Partially
4. Returned Completely

---

## Draft

A draft invoice:

- Can be edited.
- Can be deleted.
- Does NOT affect inventory.
- Does NOT affect accounting.

---

## Approved

After approval:

NEVER

- Edit the invoice.
- Delete the invoice.
- Modify prices.
- Modify quantities.

Approved invoices become historical documents.

---

## Returns

Returns NEVER modify the original invoice.

Returns ALWAYS create a NEW Return Document.

The original invoice remains unchanged forever.

---

## Return Validation

Returns require:

Invoice Barcode ONLY.

Searching by invoice number is NOT allowed for returns.

Before allowing a return, the system MUST display:

- Sold Quantity
- Already Returned Quantity
- Remaining Quantity

The returned quantity MUST NOT exceed the remaining quantity.

---

## Partial Return

Partial returns are allowed.

Invoice status becomes:

Returned Partially

---

## Full Return

When all sold quantities are returned:

Invoice status becomes:

Returned Completely

---

## Accounting

Every return creates:

- Inventory Movement
- Accounting Movement
- Customer Balance Update (if applicable)

No accounting entry may be edited after posting.
---

---

# PRODUCT & BARCODE CONSTITUTION

## Product Code

Every product has ONE permanent Product Code.

Product Code length:

8 digits.

This Product Code NEVER changes.

---

## Scale Barcode (Weighted Products)

Weighted products use a 13-digit barcode.

Structure:

First 8 digits:
Original Product Code

Last 5 digits:
Weight in grams

Example:

12345678 01250

means

Product:
12345678

Weight:
1250 grams

The system MUST automatically calculate:

Weight × Selling Price

The cashier must never enter the weight manually.

---

## Multiple Barcodes

One product may have:

- One barcode
- Two barcodes
- Unlimited barcodes

Examples:

Different fragrance

Different flavor

Different package

Different supplier barcode

All these barcodes MUST point to the SAME product.

Inventory is shared.

Sales statistics are shared.

Price is shared unless another pricing rule exists.

---

## Product Search

Searching supports:

- Partial product name
- Product Code
- Barcode

Search results appear instantly.

---

## Product Units

Every product contains:

One Base Unit

Unlimited Selling Units

Examples:

Piece

Box

Carton

Pack

Bottle

Kilogram

Gram

Inventory ALWAYS stores quantities using the Base Unit.

Every sale converts automatically to Base Unit.

Every purchase converts automatically to Base Unit.

Every return converts automatically to Base Unit.

No inventory operation may bypass unit conversion.

---

## Unit Conversion

Examples:

1 Carton = 24 Pieces

Selling 2 Cartons

Inventory decreases:

48 Pieces

Returning 1 Carton

Inventory increases:

24 Pieces

Purchasing 5 Cartons

Inventory increases:

120 Pieces

The conversion rule MUST be identical for:

Sales

Returns

Purchases

Purchase Returns

Inventory Adjustments

Transfers

---

## Historical Rule

Changing unit conversion later

MUST NOT

affect historical invoices.

Historical invoices always keep the conversion that existed on their creation date.
---

# PRICING CONSTITUTION

## Pricing Philosophy

The system MUST support multiple pricing strategies.

The active inventory costing method is selected from System Settings.

Supported costing methods:

- Last Purchase Cost
- Average Purchase Cost
- FIFO (First In First Out)

Changing the costing method affects ONLY future inventory movements.

Historical transactions MUST NEVER be recalculated.

---

## Selling Prices

Each product may contain multiple selling prices.

Supported price types:

- Retail
- Wholesale
- Special Wholesale
- Distributor
- Promotional Price

Additional price types may be added in the future.

---

## Price Integrity

Changing a product selling price:

MUST NOT

modify any historical invoice.

Every invoice stores its own selling price permanently.

Historical invoices remain unchanged forever.

---

## Purchase Cost

Purchase cost is stored for every purchase transaction.

Historical purchase costs are immutable.

Inventory valuation always follows the costing method selected in System Settings.

---

## Promotions

Promotional prices:

- Have start date.
- Have end date.
- Are applied automatically while active.
- Never overwrite the original selling price.

When promotion expires:

Original selling price becomes active automatically.

---

## Manual Price Change

Changing selling prices requires permission.

Cashiers MUST NOT modify prices.

Managers may modify prices according to permissions.

Every price modification must be logged.

The log stores:

- Product
- Old Price
- New Price
- User
- Date
- Time
- Reason (optional)

---

## Discount Rules

Discounts may be applied:

- Per Item
- Per Invoice

Discounts NEVER modify the original selling price.

Discounts exist only inside the invoice.

---

## Profit Calculation

Profit reports always use:

Inventory Cost Method

configured in System Settings.

Never calculate profit using historical selling price modifications.
---

# ACCOUNTING CONSTITUTION

## Accounting Model

The system MUST implement Full Double Entry Accounting.

Every financial transaction MUST create accounting entries automatically.

No financial operation is allowed without accounting impact.

---

## Transactions That Generate Journal Entries

The following operations MUST generate journal entries:

- Cash Sale
- Credit Sale
- Sales Return
- Purchase
- Purchase Return
- Customer Payment
- Supplier Payment
- Expense
- Income
- Cash Transfer
- Bank Transfer
- Inventory Adjustment
- Stock Count Adjustment

Future:

- Payroll
- Fixed Assets
- Manufacturing

---

## Journal Integrity

Posted journal entries:

NEVER EDIT

NEVER DELETE

If correction is required:

Create Reverse Entry

Then create Correct Entry

Historical journal entries are immutable.

---

## Posting States

Journal Entry States:

Draft

↓

Approved

↓

Posted

↓

Locked

Locked entries can never be modified.

---

## Chart Of Accounts

The system uses hierarchical Chart Of Accounts.

Main Groups:

- Assets
- Liabilities
- Equity
- Revenue
- Expenses

Users may create sub-accounts.

Main groups must never be deleted.

---

## Inventory & Accounting

Inventory and Accounting are fully integrated.

Every inventory movement with financial impact MUST create accounting entries.

Examples:

Purchase

Increase Inventory

Create Journal Entry

Sale

Decrease Inventory

Recognize Cost Of Goods Sold

Sales Return

Increase Inventory

Reverse Cost

Purchase Return

Decrease Inventory

Reverse Purchase Cost

---

## Cost Of Goods Sold

COGS MUST follow the costing method selected in System Settings.

Supported methods:

- Last Purchase Cost
- Average Cost
- FIFO

Changing costing method affects future transactions only.

Historical transactions remain unchanged forever.
---

# SECURITY & PERMISSIONS CONSTITUTION

## Security Philosophy

Every user has permissions.

No user receives permissions automatically.

Permissions are assigned through Roles only.

---

## Default Roles

The system supports the following default roles:

- Developer
- Company Owner
- General Manager
- Accountant
- Cashier
- Warehouse Keeper
- Purchasing Officer
- Sales Manager

More roles may be added later.

---

## Permission Rules

Permissions control access to:

- Screens
- Reports
- Buttons
- Actions
- Printing
- Editing
- Deleting
- Price Modification
- Accounting
- Inventory

---

## Cashier Restrictions

Cashier MUST NOT:

- Change selling prices.
- Delete invoices.
- Edit approved invoices.
- Access accounting.
- Access Developer Center.
- Change inventory quantities.
- Archive data.

---

## Accountant Permissions

Accountant may:

- View accounting reports.
- Post journal entries.
- Receive customer payments.
- Pay suppliers.
- View inventory valuation.

Accountant MUST NOT:

- Access Developer Center.
- Archive data.
- Modify inventory directly.

---

## Company Owner

Company Owner has full operational permissions.

Company Owner still CANNOT access:

Developer Center

Developer tools remain exclusive to Developer Account.

---

## Developer Account

Developer Account is completely isolated.

Developer Account:

- Does NOT appear in Users list.
- Does NOT appear in Roles.
- Cannot be edited by anyone.
- Cannot be deleted.
- Is the only account allowed to access Developer Center.

---

## Audit Log

Every critical action must be logged.

Examples:

- Price Change
- Permission Change
- User Creation
- User Deletion
- Inventory Adjustment
- Invoice Cancellation
- Backup
- Archive

Audit logs are permanent.

They must never be deleted.
---

# REPORTING CONSTITUTION

## Reporting Philosophy

Reports are read-only.

Reports NEVER modify data.

Reports are generated from historical records only.

Historical reports must always produce identical results.

---

## Report Filters

Every report MUST support:

- Date Range
- Branch (Future)
- Store
- User
- Customer (when applicable)
- Supplier (when applicable)
- Product (when applicable)
- Category (when applicable)

---

## Standard Report Actions

Every report MUST support:

- Preview
- Print
- Export PDF
- Export Excel
- Export CSV
- Share

The sharing mechanism MUST be identical across the entire system.

---

## Daily Reports

The system MUST provide:

- Daily Sales Report
- Daily Sales Returns Report
- Daily Purchases Report
- Daily Purchase Returns Report
- Daily Cash Report
- Daily Inventory Movement Report

---

## Historical Reports

All reports support:

- Single Day
- Date Range

No report is limited to one day only.

---

## Financial Reports

The system MUST support:

- Trial Balance
- General Ledger
- Customer Statement
- Supplier Statement
- Profit Report
- Inventory Valuation
- Cost Of Goods Sold

Future reports may be added without changing existing reports.

---

## Report Integrity

Reports NEVER calculate values manually.

Reports ALWAYS depend on recorded transactions.

Historical reports must never change because of future modifications.
---

# DEVELOPER CENTER CONSTITUTION

## Developer Center Philosophy

Developer Center is NOT part of the customer's ERP.

Developer Center is part of the software itself.

It exists exclusively for software maintenance, diagnostics and lifecycle management.

---

## Visibility

Developer Center MUST NEVER be visible to:

- Company Owner
- General Manager
- Accountant
- Cashier
- Warehouse Keeper
- Purchasing Officer
- Sales Manager

The customer must never know this module exists.

---

## Access

Developer Center is accessible ONLY through:

Developer Account

No operational user can access it.

---

## Developer Center Modules

The following modules MUST exist:

- License Management
- Customer Management
- Archive Management
- Fiscal Year Wizard
- Balance Carry Forward
- Reset Balances
- Database Maintenance
- Backup Center
- Restore Center
- Database Compression
- Index Rebuild
- Diagnostics
- Database Migration
- Import / Export Tools
- Maintenance Logs

---

## Maintenance Mode

The system MUST support Maintenance Mode.

While Maintenance Mode is active:

Only Developer Account may login.

All other users receive:

"The system is currently under maintenance."

---

## Backup Rules

Before executing ANY critical operation:

A Backup MUST be created.

Critical operations include:

- Archive
- Restore
- New Fiscal Year
- Reset Balances
- Database Migration
- Database Repair

If Backup creation fails:

The operation MUST stop immediately.

---

## Archive Wizard

Archive operations MUST be executed through a Wizard.

The Wizard asks:

- Archive Period
- Create New Fiscal Year?
- Carry Forward Balances?
- Reset Balances?
- Compress Database?
- Create Backup?

Only after confirmation may execution begin.

---

## Maintenance Log

Every maintenance operation MUST be logged.

The log records:

- Company
- Date
- Time
- Developer
- Operation
- Result
- Database Size Before
- Database Size After
- Backup File
- Archive File

Logs are immutable.

Logs must never be deleted.

---

## Safety Principle

Any feature capable of damaging historical data
MUST belong to Developer Center only.

Never expose these tools to customers.
## Transaction Engine Rule

Never update inventory directly.

Never update accounting directly.

Never update balances directly.

Always use the SmartPOS Transaction Engine.

If the Transaction Engine does not exist:

Create it first.

Every business workflow must call the Transaction Engine instead of implementing business logic inside UI screens.