# SmartPOS ERP
# ARCHITECTURAL DECISIONS (ADR)

Version: 1.0

---

# PURPOSE

This file contains every approved architectural and business decision.

These decisions are immutable.

If a decision changes:

Never delete it.

Create a new decision that replaces it.

---

# DECISION FORMAT

Decision Number

Status

Description

Reason

Date

Replaced By (Optional)

---

# APPROVED DECISIONS

---

ADR-001

Status:
APPROVED

Project Architecture:

Clean Architecture

DDD

MVVM

.NET 8 WPF

---

ADR-002

Status:
APPROVED

Historical invoices are immutable.

Approved invoices:

Never Edit

Never Delete

---

ADR-003

Status:
APPROVED

Returns create NEW documents.

Original invoices remain unchanged forever.

---

ADR-004

Status:
APPROVED

Returns require Invoice Barcode.

Invoice Number is not used for returns.

---

ADR-005

Status:
APPROVED

Invoice Barcode exists on every invoice.

Future versions may support Product Barcode inside invoice.

---

ADR-006

Status:
APPROVED

Weighted barcode:

13 digits

First 8 digits:

Original Product Code

Last 5 digits:

Weight in grams.

---

ADR-007

Status:
APPROVED

One product may have unlimited barcodes.

Inventory remains shared.

---

ADR-008

Status:
APPROVED

Inventory always stores Base Unit.

Every transaction converts automatically.

---

ADR-009

Status:
APPROVED

Unit conversion applies to:

Sales

Sales Returns

Purchases

Purchase Returns

Transfers

Inventory Adjustments

---

ADR-010

Status:
APPROVED

Supported Cost Methods:

Last Purchase

Average Cost

FIFO

Selectable from System Settings.

---

ADR-011

Status:
APPROVED

Cashier cannot modify prices.

Every price modification is logged.

---

ADR-012

Status:
APPROVED

Reports support:

Print

PDF

Excel

CSV

Share

Sharing mechanism is unified.

---

ADR-013

Status:
APPROVED

Developer Center is invisible to customers.

Only Developer Account may access it.

---

ADR-014

Status:
APPROVED

Backup is mandatory before:

Archive

Restore

New Fiscal Year

Database Migration

Database Repair

---

ADR-015

Status:
APPROVED

Developer Center contains:

License Manager

Archive

Backup

Restore

Fiscal Year Wizard

Database Maintenance

Diagnostics

Migration

Maintenance Logs

---

ADR-016

Status:
APPROVED

Every financial operation generates accounting entries.

Full Double Entry Accounting.

---

ADR-017

Status:
APPROVED

Inventory and Accounting are fully integrated.

---

ADR-018

Status:
APPROVED

POS Layout is fixed.

Barcode Box

↓

Quick Products

↓

Search Box

↓

Categories

↓

Shopping Cart

---

ADR-019

Status:
APPROVED

F2

Hold Invoice

---

ADR-020

Status:
APPROVED

F3

Finish Invoice

---

ADR-021

Status:
APPROVED

F9

Product Lookup

---

ADR-022

Status:
APPROVED

F10

Invoice Lookup

---

END OF DOCUMENT
---

ADR-023

Status:
APPROVED

Default Customer for new invoice:

Cash Customer

---

ADR-024

Status:
APPROVED

Default Warehouse:

Main Store

---

ADR-025

Status:
APPROVED

Default Selling Unit:

Base Unit

---

ADR-026

Status:
APPROVED

Default Payment Method:

Cash

---

ADR-027

Status:
APPROVED

Paid Amount defaults to Invoice Total.

---

ADR-028

Status:
APPROVED

Pressing F3 moves focus directly to Paid Amount.

---

ADR-029

Status:
APPROVED

Press Enter without changing Paid Amount:

Approve Invoice

Print Invoice

Open New Invoice

---

ADR-030

Status:
APPROVED

If Paid Amount is modified then Enter:

Calculate Change

Approve

Print

Open New Invoice

---

ADR-031

Status:
APPROVED

Credit customers may partially pay invoices.

Remaining balance becomes Customer Debt automatically.

---

ADR-032

Status:
APPROVED

Invoice Number is unique forever.

Invoice numbers are never reused.

---

ADR-033

Status:
APPROVED

Every invoice contains its own barcode.

Invoice Barcode uniquely identifies the invoice.

---

ADR-034

Status:
APPROVED

Invoice Lookup supports:

Invoice Barcode

Invoice Number

Customer

Phone

Date

Product

---

ADR-035

Status:
APPROVED

Invoice Lookup allows:

View

Print

Return

Share

View Cashier

View Payment Details

---

ADR-036

Status:
APPROVED

Every invoice stores:

Creator User

Date

Time

Device (future)

Branch (future)

---

ADR-037

Status:
APPROVED

Held Invoices (F2)

Do NOT affect inventory.

Do NOT affect accounting.

Remain Draft until completed.

---

ADR-038

Status:
APPROVED

Held invoices may be restored only through F4.

---

ADR-039

Status:
APPROVED

Barcode Scanner is the primary input device.

Mouse usage should be minimized.

---

ADR-040

Status:
APPROVED

The cashier should complete an average sale using keyboard and barcode scanner with minimum clicks.
---

ADR-041

Status:
APPROVED

The system supports multiple active price lists.

---

ADR-042

Status:
APPROVED

Price Lists may be assigned per Customer.

---

ADR-043

Status:
APPROVED

Promotional prices have Start Date and End Date.

---

ADR-044

Status:
APPROVED

Expired promotional prices are disabled automatically.

---

ADR-045

Status:
APPROVED

Manual discounts require permission.

---

ADR-046

Status:
APPROVED

Invoice discount never changes Product Selling Price.

---

ADR-047

Status:
APPROVED

Item discount is stored separately from Selling Price.

---

ADR-048

Status:
APPROVED

Profit reports use Inventory Cost Method only.

---

ADR-049

Status:
APPROVED

Customer balance is updated immediately after invoice approval.

---

ADR-050

Status:
APPROVED

Supplier balance is updated immediately after purchase approval.

---

ADR-051

Status:
APPROVED

Customer payment creates Receipt Voucher automatically.

---

ADR-052

Status:
APPROVED

Supplier payment creates Payment Voucher automatically.

---

ADR-053

Status:
APPROVED

Purchases increase inventory immediately after approval.

---

ADR-054

Status:
APPROVED

Purchase Returns decrease inventory immediately after approval.

---

ADR-055

Status:
APPROVED

Purchase Returns create independent documents.

Original Purchase Invoice remains unchanged.

---

ADR-056

Status:
APPROVED

Purchase Invoice stores Purchase Cost permanently.

---

ADR-057

Status:
APPROVED

Changing Purchase Cost later never modifies historical purchases.

---

ADR-058

Status:
APPROVED

Inventory Transfers create Inventory Movement records.

---

ADR-059

Status:
APPROVED

Inventory Transfers never affect accounting directly.

Unless financial valuation is enabled in future versions.

---

ADR-060

Status:
APPROVED

Every Inventory Movement must be traceable forever.
---

ADR-061

Status:
APPROVED

Inventory Count is performed using a dedicated Inventory Count Document.

---

ADR-062

Status:
APPROVED

Inventory Count never edits inventory directly.

Differences are posted through Inventory Adjustment transactions.

---

ADR-063

Status:
APPROVED

Inventory Adjustments require manager approval.

---

ADR-064

Status:
APPROVED

Every Inventory Adjustment generates:

- Inventory Movement
- Journal Entry (when applicable)
- Audit Log

---

ADR-065

Status:
APPROVED

All reports support:

- Single Day
- Date Range

No report is limited to today's transactions only.

---

ADR-066

Status:
APPROVED

Daily reports include:

- Daily Sales
- Daily Sales Returns
- Daily Purchases
- Daily Purchase Returns
- Daily Cash
- Daily Inventory Movement

---

ADR-067

Status:
APPROVED

Report sharing mechanism is unified across the entire system.

---

ADR-068

Status:
APPROVED

Supported report export formats:

- PDF
- Excel
- CSV

---

ADR-069

Status:
APPROVED

Developer Center is the only module allowed to archive data.

---

ADR-070

Status:
APPROVED

Archiving always requires Backup before execution.

If Backup fails:

Archive MUST stop.

---

ADR-071

Status:
APPROVED

Opening a New Fiscal Year is performed only through Developer Center Wizard.

---

ADR-072

Status:
APPROVED

Balance Carry Forward is executed automatically during Fiscal Year creation.

---

ADR-073

Status:
APPROVED

Archived years remain available for reporting.

Archived data is Read Only.

---

ADR-074

Status:
APPROVED

Database Maintenance is available only inside Developer Center.

---

ADR-075

Status:
APPROVED

Database Maintenance includes:

- Database Compression
- Index Rebuild
- Integrity Check
- Temporary Data Cleanup

---

ADR-076

Status:
APPROVED

Every maintenance operation is logged permanently.

---

ADR-077

Status:
APPROVED

Maintenance Log stores:

- Company
- Developer
- Date
- Time
- Operation
- Result

---

ADR-078

Status:
APPROVED

Database Restore is allowed only after explicit confirmation.

---

ADR-079

Status:
APPROVED

Developer Center supports multiple companies and multiple databases.

---

ADR-080

Status:
APPROVED

Customer-facing users must never know Developer Center exists.
---

ADR-081

Status:
APPROVED

The POS screen must always prioritize speed over visual effects.

---

ADR-082

Status:
APPROVED

Touch Screen support is mandatory.

All important operations must be executable without keyboard.

---

ADR-083

Status:
APPROVED

Barcode Scanner is considered the primary input device.

The UI must never slow barcode entry.

---

ADR-084

Status:
APPROVED

The barcode input must automatically regain focus after every completed operation.

---

ADR-085

Status:
APPROVED

The system must continue operating during temporary network outages.

Offline capability is a design priority.

---

ADR-086

Status:
APPROVED

The application startup time should be minimized.

Avoid unnecessary loading during startup.

---

ADR-087

Status:
APPROVED

No operation should require more than the minimum number of user interactions.

---

ADR-088

Status:
APPROVED

Every critical operation must display a confirmation dialog before execution.

---

ADR-089

Status:
APPROVED

Every destructive operation must be reversible whenever possible.

---

ADR-090

Status:
APPROVED

Every important business event must be traceable through Audit Logs.

---

ADR-091

Status:
APPROVED

GitHub Repository is the single Source of Truth.

No local version is considered official unless pushed.

---

ADR-092

Status:
APPROVED

Every Sprint must end with:

Successful Build

Commit

Push

Documentation Update

---

ADR-093

Status:
APPROVED

Every approved business rule must be documented before implementation.

---

ADR-094

Status:
APPROVED

Business Rules always have higher priority than implementation details.

---

ADR-095

Status:
APPROVED

If implementation conflicts with Business Rules:

Implementation must change.

Business Rules remain unchanged until officially replaced.

---

ADR-096

Status:
APPROVED

Artificial Intelligence tools must follow AGENTS.md before generating or modifying code.

---

ADR-097

Status:
APPROVED

Artificial Intelligence tools must never redesign approved workflows.

---

ADR-098

Status:
APPROVED

If required information is missing:

STOP

Ask the user.

Never guess.

---

ADR-099

Status:
APPROVED

The SmartPOS ERP Constitution is the highest authority of the project.

All documentation derives from it.

---

ADR-100

Status:
APPROVED

SmartPOS ERP shall prioritize:

Data Integrity

Business Accuracy

Performance

Maintainability

User Simplicity

Above implementation convenience.

---

END OF ARCHITECTURAL DECISIONS
ADR-133

Unified Transaction Engine

All business transactions MUST pass through a single Transaction Engine.

No screen is allowed to modify:

- Inventory
- Accounting
- Customer Balance
- Supplier Balance
- Cash Box
- Audit Log

directly.

Every transaction must execute through the Transaction Engine.
---

ADR-122

Status:
APPROVED

Cash Shift System can be enabled or disabled from System Settings.

---

ADR-123

Status:
APPROVED

Every user is assigned a default Cash Box.

---

ADR-124

Status:
APPROVED

A user cannot sell from another Cash Box unless explicitly authorized.

---

ADR-125

Status:
APPROVED

Opening Shift requires:

- Cash Box
- User
- Opening Balance

---

ADR-126

Status:
APPROVED

Every Cash Shift receives a unique Shift Number.

---

ADR-127

Status:
APPROVED

A Cash Shift stores:

- Opening Date
- Opening Time
- Closing Date
- Closing Time
- User
- Cash Box

---

ADR-128

Status:
APPROVED

Only one Open Shift is allowed per Cash Box.

---

ADR-129

Status:
APPROVED

Sales are linked to the currently opened Cash Shift.

---

ADR-130

Status:
APPROVED

Cash Receipts increase Cash Box balance immediately.

---

ADR-131

Status:
APPROVED

Cash Payments decrease Cash Box balance immediately.

---

ADR-132

Status:
APPROVED

Cash Transfers between Cash Boxes create Transfer Documents.

---

ADR-133

Status:
APPROVED

Transfers require:

- Source Cash Box
- Destination Cash Box
- Amount
- User
- Reason

---

ADR-134

Status:
APPROVED

Cash Box Closing calculates automatically:

- Opening Balance
- Sales
- Receipts
- Payments
- Expenses
- Cash Transfers
- Expected Closing Balance

---

ADR-135

Status:
APPROVED

Actual Cash Count is entered manually during Closing Shift.

---

ADR-136

Status:
APPROVED

The system calculates Cash Difference automatically.

---

ADR-137

Status:
APPROVED

Cash Difference never modifies accounting automatically.

Manager approval is required.

---

ADR-138

Status:
APPROVED

Closed Shifts become Read Only.

---

ADR-139

Status:
APPROVED

Cash Box Reports support:

- Daily
- Date Range
- User
- Cash Box

---

ADR-140

Status:
APPROVED

Cash Box Reports support:

- Preview
- PDF
- Excel
- CSV
- Unified Share System
---

ADR-141

Status:
APPROVED

Cash Boxes support independent financial movements outside Sales.

---

ADR-142

Status:
APPROVED

Supported Cash Box transactions:

- Cash In
- Cash Out
- Cash Transfer
- Bank Deposit
- Bank Withdrawal
- Opening Balance
- Closing Difference

---

ADR-143

Status:
APPROVED

Every Cash Movement must contain:

- Date
- Time
- User
- Cash Box
- Amount
- Reason
- Notes (Optional)

---

ADR-144

Status:
APPROVED

Cash In transactions increase Cash Box balance immediately.

---

ADR-145

Status:
APPROVED

Cash Out transactions decrease Cash Box balance immediately.

---

ADR-146

Status:
APPROVED

Cash Transfers create two linked movements:

- Source Cash Box (Out)
- Destination Cash Box (In)

---

ADR-147

Status:
APPROVED

Deleting Cash Movements is prohibited.

Correction must be performed using Reverse Transactions.

---

ADR-148

Status:
APPROVED

Every Cash Movement receives a unique sequential number.

---

ADR-149

Status:
APPROVED

Cash Box balance is calculated from transaction history.

Current Balance must never be stored manually.

---

ADR-150

Status:
APPROVED

Cash Box balance can always be recalculated from movement history.
# Batch-07
# OFFERS ENGINE
# ADR-161 → ADR-180

---

ADR-161

Status:
APPROVED

The system shall use a centralized Offers Engine.

All promotions must be processed only through the Offers Engine.

---

ADR-162

Status:
APPROVED

Offers never modify Product Selling Price.

Offers are calculated during invoice processing only.

---

ADR-163

Status:
APPROVED

Every offer has:

- Name
- Code
- Status
- Start Date
- End Date
- Priority

---

ADR-164

Status:
APPROVED

Expired offers become inactive automatically.

---

ADR-165

Status:
APPROVED

Offers may be:

- Active
- Inactive
- Scheduled
- Expired

---

ADR-166

Status:
APPROVED

Offers support:

- Percentage Discount
- Fixed Amount Discount
- Buy X Get Y
- Quantity Discount
- Bundle Offer

---

ADR-167

Status:
APPROVED

Offers may target:

- Product
- Category
- Brand
- Supplier
- Customer
- Customer Group

---

ADR-168

Status:
APPROVED

Offers may require:

- Minimum Quantity
- Minimum Amount

---

ADR-169

Status:
APPROVED

Every offer has execution priority.

Highest priority executes first.

---

ADR-170

Status:
APPROVED

Offer conflicts are resolved automatically using Priority.

---

ADR-171

Status:
APPROVED

Stacking multiple offers is disabled by default.

---

ADR-172

Status:
APPROVED

Administrator may enable Offer Stacking from Settings.

---

ADR-173

Status:
APPROVED

Invoice stores:

- Offer Name
- Offer ID
- Discount Value

for every applied offer.

---

ADR-174

Status:
APPROVED

Removing an item automatically recalculates all offers.

---

ADR-175

Status:
APPROVED

Changing quantity automatically recalculates all offers.

---

ADR-176

Status:
APPROVED

Changing unit automatically recalculates all offers.

---

ADR-177

Status:
APPROVED

Offers are recalculated before invoice approval.

---

ADR-178

Status:
APPROVED

Cancelled invoices restore consumed offers immediately.

---

ADR-179

Status:
APPROVED

Returned invoices reverse applied offers automatically.

---

ADR-180

Status:
APPROVED

Every applied offer is stored permanently inside invoice history.
---

ADR-185

Status:
APPROVED

The Purchase Module supports:

- Purchase Invoice
- Purchase Return
- Purchase Draft
- Purchase Approval

---

ADR-186

Status:
APPROVED

Purchase Invoices receive automatic sequential numbering.

Manual numbering is optional.

---

ADR-187

Status:
APPROVED

Purchase Invoice Header contains:

- Supplier
- Invoice Number
- Invoice Date
- Warehouse
- Purchase Type
- Payment Method
- Currency
- Notes

---

ADR-188

Status:
APPROVED

Purchase lines support:

- Product
- Unit
- Quantity
- Purchase Price
- Discount
- Tax
- Expiry Date (Future Feature)
- Batch Number (Future Feature)

---

ADR-189

Status:
APPROVED

Products may be added using:

- Barcode Scanner
- Product Search
- Quick Create
- Smart Receiving

---

ADR-190

Status:
APPROVED

When barcode is unknown:

Open Quick Create.

Return automatically to Purchase Invoice.

---

ADR-191

Status:
APPROVED

Purchase Invoice supports unlimited number of items.

---

ADR-192

Status:
APPROVED

Purchase Invoice supports editing before approval.

---

ADR-193

Status:
APPROVED

Approved Purchase Invoice becomes Read Only.

---

ADR-194

Status:
APPROVED

Cancelling Purchase Invoice requires reverse inventory movement.

---

ADR-195

Status:
APPROVED

Purchase Invoice updates inventory immediately after approval.

---

ADR-196

Status:
APPROVED

Purchase Invoice updates product cost according to selected Cost Method.

---

ADR-197

Status:
APPROVED

Purchase Invoice automatically generates accounting entries.

---

ADR-198

Status:
APPROVED

Purchase Invoice supports direct barcode printing for received products.

---

ADR-199

Status:
APPROVED

Barcode Printing supports:

- One Label
- Multiple Labels
- Selected Unit
- Selected Barcode

---

ADR-200

Status:
APPROVED

Purchase Invoice supports:

Preview

Print

PDF

Excel

CSV

Unified Share System
---

ADR-202

Status:
APPROVED

The system supports Purchase Return documents.

---

ADR-203

Status:
APPROVED

Purchase Return can only be created from an approved Purchase Invoice.

Manual Purchase Return is prohibited by default.

---

ADR-204

Status:
APPROVED

Purchase Return automatically imports:

- Supplier
- Products
- Units
- Purchase Prices

from the original Purchase Invoice.

---

ADR-205

Status:
APPROVED

Returned Quantity cannot exceed Remaining Quantity.

Remaining Quantity =
Purchased Quantity
− Previous Purchase Returns

---

ADR-206

Status:
APPROVED

Purchase Return supports Unit System.

Returning one carton deducts:

Carton Conversion Quantity

from inventory.

---

ADR-207

Status:
APPROVED

Purchase Return updates inventory immediately after approval.

---

ADR-208

Status:
APPROVED

Purchase Return decreases supplier balance automatically.

---

ADR-209

Status:
APPROVED

Purchase Return generates reverse accounting entries automatically.

---

ADR-210

Status:
APPROVED

Purchase Return preserves original purchase cost.

Cost is never recalculated by Purchase Return.

---

ADR-211

Status:
APPROVED

Purchase Return supports:

- Partial Return
- Full Return

---

ADR-212

Status:
APPROVED

Purchase Return may include Return Reason.

Examples:

- Damaged
- Expired
- Wrong Item
- Wrong Quantity
- Supplier Error
- Other

---

ADR-213

Status:
APPROVED

Purchase Return Number is generated automatically.

---

ADR-214

Status:
APPROVED

Purchase Return is Read Only after approval.

---

ADR-215

Status:
APPROVED

Deleting approved Purchase Return is prohibited.

Correction requires Reverse Transaction.

---

ADR-216

Status:
APPROVED

Purchase Return supports:

Preview

Print

PDF

Excel

CSV

Unified Share System

---

ADR-217

Status:
APPROVED

Purchase Return stores:

Original Purchase Invoice Number.

---

ADR-218

Status:
APPROVED

Purchase Return stores:

User

Date

Time

Reason

Warehouse

---

ADR-219

Status:
APPROVED

Purchase Return updates Product Movement History automatically.

---

ADR-220

Status:
APPROVED

Purchase Return is processed only through the SmartPOS Transaction Engine.
# Batch-09
# INVENTORY COUNT
# ADR-222 → ADR-240

---

ADR-222

Status:
APPROVED

The system supports Inventory Count.

---

ADR-223

Status:
APPROVED

Inventory Count Types:

- Full Inventory
- Partial Inventory

---

ADR-224

Status:
APPROVED

Inventory Count may be filtered by:

- Warehouse
- Category
- Supplier
- Brand
- Shelf
- Selected Products

---

ADR-225

Status:
APPROVED

Inventory Count supports Barcode Scanner.

---

ADR-226

Status:
APPROVED

Scanning a barcode increases Counted Quantity automatically.

---

ADR-227

Status:
APPROVED

Manual quantity entry remains available.

---

ADR-228

Status:
APPROVED

Inventory Count supports Product Units.

The counted quantity is converted automatically to the base unit.

---

ADR-229

Status:
APPROVED

System Quantity is displayed separately from Counted Quantity.

---

ADR-230

Status:
APPROVED

Difference is calculated automatically.

Difference =
Counted Quantity
− System Quantity

---

ADR-231

Status:
APPROVED

Inventory Count Status:

- Draft
- In Progress
- Approved
- Cancelled

---

ADR-232

Status:
APPROVED

Draft Inventory Counts do not affect stock.

---

ADR-233

Status:
APPROVED

Only Approved Inventory Counts update stock balances.

---

ADR-234

Status:
APPROVED

Approving Inventory Count automatically creates Inventory Adjustment Transactions.

---

ADR-235

Status:
APPROVED

Inventory Count automatically generates accounting entries when accounting integration is enabled.

---

ADR-236

Status:
APPROVED

Approved Inventory Counts become Read Only.

---

ADR-237

Status:
APPROVED

Deleting Approved Inventory Counts is prohibited.

Corrections require Adjustment Transactions.

---

ADR-238

Status:
APPROVED

Inventory Count supports:

- Preview
- Print
- PDF
- Excel
- CSV
- Unified Share System

---

ADR-239

Status:
APPROVED

Inventory Count stores:

- User
- Date
- Time
- Warehouse
- Notes

---

ADR-240

Status:
APPROVED

Inventory Count is executed only through the SmartPOS Transaction Engine.
---

ADR-241

Status:
APPROVED

Inventory Count supports Multi-Device Counting.

---

ADR-242

Status:
APPROVED

Multiple users may participate in the same Inventory Count simultaneously.

---

ADR-243

Status:
APPROVED

Each user may be assigned one or more:

- Sections
- Shelves
- Categories
- Product Ranges

---

ADR-244

Status:
APPROVED

Two users cannot count the same assigned section simultaneously unless the administrator explicitly allows overlapping.

---

ADR-245

Status:
APPROVED

Every counted item stores:

- User
- Device
- Date
- Time

---

ADR-246

Status:
APPROVED

Inventory Count Progress is displayed in real time.

Examples:

Completed Products

Remaining Products

Completion Percentage

---

ADR-247

Status:
APPROVED

The Inventory Manager can monitor all counting devices live.

---

ADR-248

Status:
APPROVED

If a device disconnects from the network:

The counted data remains محفوظًا locally.

Synchronization starts automatically once the connection returns.

---

ADR-249

Status:
APPROVED

Inventory Count supports Pause and Resume.

---

ADR-250

Status:
APPROVED

Inventory Count supports unlimited participating devices inside the same local network.
docs/architectural/batch-10.md
---

ADR-251

Status:
APPROVED

The system supports Blind Inventory Count.

---

ADR-252

Status:
APPROVED

When Blind Count is enabled:

The counter cannot see:

- System Quantity
- Inventory Difference
- Expected Stock

Only:

- Product
- Barcode
- Unit

are displayed.

---

ADR-253

Status:
APPROVED

Only authorized users may view inventory differences before approval.

Default:

- Inventory Manager
- Administrator

---

ADR-254

Status:
APPROVED

Blind Count can be enabled:

- Per Inventory Session
- Or globally from System Settings

---

ADR-255

Status:
APPROVED

Blind Count remains fully compatible with:

- Barcode Scanner
- Multi-Device Counting
- Unit System

---

ADR-256

Status:
APPROVED

Inventory differences become visible only after the Inventory Session is approved or explicitly revealed by an authorized user.

---

ADR-257

Status:
APPROVED

Every Inventory Session records:

- Blind Count Enabled (Yes/No)

for auditing purposes.
# Batch-10
# REPORTING ENGINE
# ADR-261 → ADR-280

---

ADR-261

Status:
APPROVED

The system shall use a centralized Reporting Engine.

All reports must be generated through the Reporting Engine.

---

ADR-262

Status:
APPROVED

Every report supports:

- Preview
- Print
- PDF
- Excel
- CSV

---

ADR-263

Status:
APPROVED

All reports use one Unified Share System.

Sharing methods:

- WhatsApp
- Email
- Save File
- Print

---

ADR-264

Status:
APPROVED

Every report supports Date Range filtering.

---

ADR-265

Status:
APPROVED

Reports may support additional filters according to report type.

Examples:

- Warehouse
- Supplier
- Customer
- User
- Cash Box
- Category

---

ADR-266

Status:
APPROVED

Reports remember the last used filters for every user.

---

ADR-267

Status:
APPROVED

Reports may be exported without opening Preview.

---

ADR-268

Status:
APPROVED

Large reports load using pagination.

---

ADR-269

Status:
APPROVED

Reports may be sorted by any visible column.

---

ADR-270

Status:
APPROVED

Reports support live searching.

---

ADR-271

Status:
APPROVED

Reports support grouping.

Examples:

- By Date
- By Supplier
- By Customer
- By Category

---

ADR-272

Status:
APPROVED

Reports display totals automatically.

---

ADR-273

Status:
APPROVED

Financial reports display:

- Total
- Discount
- Tax
- Net Amount

where applicable.

---

ADR-274

Status:
APPROVED

Reports respect user permissions.

Unauthorized reports remain hidden.

---

ADR-275

Status:
APPROVED

Reports always show:

- Report Name
- Print Date
- User
- Company Name

---

ADR-276

Status:
APPROVED

Reports support company logo printing.

---

ADR-277

Status:
APPROVED

Reports automatically use paper size configured in system settings.

---

ADR-278

Status:
APPROVED

Reports support Dark Mode and Light Mode previews.

---

ADR-279

Status:
APPROVED

Reports never modify business data.

Reports are Read Only.

---

ADR-280

Status:
APPROVED

Every module uses the same Reporting Engine.
---

## ADR-281

**Status:** APPROVED

### Title
Favorite Reports

### Rule

The system SHALL support Favorite Reports.

Each user SHALL have an independent list of favorite reports.

Favorite reports SHALL NOT be shared between users.

---

## ADR-282

**Status:** APPROVED

### Title
Independent Favorite Reports

### Rule

Favorite Reports are user-specific.

Saving or deleting favorites SHALL affect only the current user.

---

## ADR-283

**Status:** APPROVED

### Title
Favorite Toggle

### Rule

Every report SHALL provide a Favorite toggle.

Users MAY:

- Add report to favorites.
- Remove report from favorites.

---

## ADR-284

**Status:** APPROVED

### Title
Favorite Reports Location

### Rule

Favorite Reports SHALL appear in:

- Dashboard
- Reporting Module

---

## ADR-285

**Status:** APPROVED

### Title
Favorite Ordering

### Rule

Users SHALL be able to reorder Favorite Reports using Drag & Drop.

Order SHALL be stored per user.

---

## ADR-286

**Status:** APPROVED

### Title
Recent Reports

### Rule

The system SHALL maintain Recent Reports.

Maximum stored entries:

20 reports per user.

Older entries SHALL be removed automatically.

---

## ADR-287

**Status:** APPROVED

### Title
Report Search

### Rule

Reporting Module SHALL support searching reports by name.

Search SHALL be case-insensitive.

Partial text matching SHALL be supported.

---

## ADR-288

**Status:** APPROVED

### Title
Report Categories

### Rule

Reports SHALL be organized into categories.

Default categories:

- Sales
- Purchases
- Inventory
- Customers
- Suppliers
- Cash Boxes
- Accounting
- Administration

---

## ADR-289

**Status:** APPROVED

### Title
Permission Filtering

### Rule

Users SHALL only see report categories and reports permitted by their assigned role.

Unauthorized reports SHALL remain hidden.

---

## ADR-290

**Status:** APPROVED

### Title
Extensible Reporting Engine

### Rule

Reporting Engine SHALL support adding new reports without modifying existing reports.

New reports SHALL be registered using the Reporting Engine registration mechanism.

---

## ADR-291

**Status:** APPROVED

### Title
Report Templates

### Rule

The system SHALL support Report Templates.

Templates SHALL save report configuration only.

Templates SHALL NOT save report data.

---

## ADR-292

**Status:** APPROVED

### Title
User Report Templates

### Rule

Each user SHALL own independent Report Templates.

Templates SHALL be private unless explicitly published.

---

## ADR-293

**Status:** APPROVED

### Title
Template Contents

### Rule

A Report Template SHALL store:

- Report Type
- Filters
- Sorting
- Grouping
- Visible Columns

---

## ADR-294

**Status:** APPROVED

### Title
Template Management

### Rule

Users MAY:

- Create Template
- Rename Template
- Duplicate Template
- Delete Template

---

## ADR-295

**Status:** APPROVED

### Title
Global Templates

### Rule

Administrators MAY publish Global Report Templates.

Global Templates SHALL be available to authorized users.

---

## ADR-296

**Status:** APPROVED

### Title
Live Data

### Rule

Report Templates SHALL always execute against live data.

Cached report results SHALL NOT be stored.

---

## ADR-297

**Status:** APPROVED

### Title
Favorite Templates

### Rule

Users MAY mark Report Templates as favorites.

Favorite Templates SHALL appear in Dashboard and Reporting Module.

---

## ADR-298

**Status:** APPROVED

### Title
Template Sharing

### Rule

Report Templates SHALL support the Unified Share System.

Supported outputs:

- PDF
- Excel
- CSV
- Print
- WhatsApp
- Email

---

## ADR-299

**Status:** APPROVED

### Title
Dashboard Integration

### Rule

Reporting Engine SHALL be designed to support Dashboard Widgets without architectural modifications.

---

## ADR-300

**Status:** APPROVED

### Title
Future Dashboard Compatibility

### Rule

Every report SHALL expose reusable data providers to support future Dashboard implementation.

---

## ADR-301

**Status:** APPROVED

### Title
Dynamic Report Builder

### Rule

Dynamic Report Builder is deferred to Version 2.0.

The current Reporting Engine architecture SHALL remain compatible with future implementation without requiring redesign.
# Batch-11
# CUSTOMER MANAGEMENT
# ADR-302 → ADR-320

---

## ADR-302

**Status:** APPROVED

### Title

Default Cash Customer

### Rule

The system SHALL include a permanent Default Cash Customer.

This customer SHALL NOT be deleted.

This customer SHALL be used automatically for cash sales unless another customer is selected.

---
# Batch-11
# BUSINESS PARTNERS
# ADR-303 → ADR-320

---

## ADR-303

**Status:** APPROVED

### Title

Business Partner Types

### Rule

The system SHALL support:

- Customer
- Supplier
- Customer & Supplier

A single Business Partner MAY have more than one role.

---

## ADR-304

**Status:** APPROVED

### Title

Partner Code

### Rule

Every Business Partner SHALL have a unique Partner Code.

Partner Code MAY be generated automatically.

Manual entry MAY be allowed according to System Settings.

---

## ADR-305

**Status:** APPROVED

### Title

Partner Name

### Rule

Partner Name is mandatory.

Duplicate names are allowed.

Partner Code SHALL remain unique.

---

## ADR-306

**Status:** APPROVED

### Title

Phone Numbers

### Rule

Business Partner SHALL support multiple phone numbers.

One phone number SHALL be marked as Primary.

---

## ADR-307

**Status:** APPROVED

### Title

Address

### Rule

Business Partner SHALL support:

- Country
- Governorate
- City
- District
- Street
- Notes

All fields are optional.

---

## ADR-308

**Status:** APPROVED

### Title

Commercial Information

### Rule

Business Partner SHALL support storing:

- Tax Number
- Commercial Registration
- National ID

All fields are optional.

---

## ADR-309

**Status:** APPROVED

### Title

Opening Balance

### Rule

Opening Balance SHALL be entered during Partner creation.

Opening Balance SHALL generate accounting entries automatically.

---

## ADR-310

**Status:** APPROVED

### Title

Credit Limit

### Rule

Credit Limit applies only when Partner has Customer role.

Supplier role ignores Credit Limit.

---

## ADR-311

**Status:** APPROVED

### Title

Partner Status

### Rule

Partner Status SHALL support:

- Active
- Suspended
- Archived

Archived partners remain available in history.

---

## ADR-312

**Status:** APPROVED

### Title

Partner Notes

### Rule

Unlimited notes SHALL be supported.

---

## ADR-313

**Status:** APPROVED

### Title

Quick Creation

### Rule

Cashier MAY create a Business Partner directly from POS.

Minimum required field:

- Name

---

## ADR-314

**Status:** APPROVED

### Title

Partner Search

### Rule

Search SHALL support:

- Name
- Code
- Phone Number

Search SHALL support partial matching.

---

## ADR-315

**Status:** APPROVED

### Title

Partner History

### Rule

Complete transaction history SHALL be preserved permanently.

History SHALL NEVER be deleted.

---

## ADR-316

**Status:** APPROVED

### Title

Partner Audit

### Rule

Partner creation and modification SHALL store:

- User
- Date
- Time

---

## ADR-317

**Status:** APPROVED

### Title

Partner Attachments

### Rule

Business Partner SHALL support file attachments.

Examples:

- Contracts
- IDs
- Tax Documents
- Images

---

## ADR-318

**Status:** APPROVED

### Title

Partner Tags

### Rule

Business Partner MAY contain unlimited tags.

Example:

- VIP
- Wholesale
- Restaurant
- Pharmacy

---

## ADR-319

**Status:** APPROVED

### Title

Partner Categories

### Rule

Business Partner MAY belong to one Category.

Category is optional.

---

## ADR-320

**Status:** APPROVED

### Title

Business Partner Engine

### Rule

All Customer and Supplier operations SHALL use the unified Business Partner Engine.
---

## ADR-321

**Status:** APPROVED

### Title

Business Partner Financial Wallet

### Rule

Every Business Partner SHALL have one Financial Wallet.

The Financial Wallet SHALL represent the financial status of the partner.

---

## ADR-322

**Status:** APPROVED

### Title

Current Balance

### Rule

Financial Wallet SHALL maintain Current Balance.

Current Balance SHALL always equal the sum of all approved financial transactions.

---

## ADR-323

**Status:** APPROVED

### Title

Reserved Balance

### Rule

Financial Wallet SHALL support Reserved Balance.

Reserved Balance SHALL be used for future reserved transactions.

Default value = 0.

---

## ADR-324

**Status:** APPROVED

### Title

Outstanding Balance

### Rule

Financial Wallet SHALL calculate Outstanding Balance automatically.

Outstanding Balance SHALL represent unpaid obligations.

---

## ADR-325

**Status:** APPROVED

### Title

Last Transaction

### Rule

Financial Wallet SHALL store:

- Last Transaction Date
- Last Transaction Type
- Last Transaction Amount

---

## ADR-326

**Status:** APPROVED

### Title

Sales Statistics

### Rule

Financial Wallet SHALL maintain:

- Total Sales
- Sales Count

Automatically.

---

## ADR-327

**Status:** APPROVED

### Title

Purchase Statistics

### Rule

Financial Wallet SHALL maintain:

- Total Purchases
- Purchase Count

Automatically.

---

## ADR-328

**Status:** APPROVED

### Title

Receipt Statistics

### Rule

Financial Wallet SHALL maintain:

- Total Receipts
- Receipt Count

Automatically.

---

## ADR-329

**Status:** APPROVED

### Title

Payment Statistics

### Rule

Financial Wallet SHALL maintain:

- Total Payments
- Payment Count

Automatically.

---

## ADR-330

**Status:** APPROVED

### Title

Returns Statistics

### Rule

Financial Wallet SHALL maintain:

- Sales Returns
- Purchase Returns

Automatically.

---

## ADR-331

**Status:** APPROVED

### Title

Wallet Calculation

### Rule

Financial Wallet SHALL NEVER be edited manually.

All values SHALL be generated only through the Transaction Engine.

---

## ADR-332

**Status:** APPROVED

### Title

Wallet Consistency

### Rule

Financial Wallet SHALL always remain synchronized with accounting entries.

---

## ADR-333

**Status:** APPROVED

### Title

Real-Time Updates

### Rule

Financial Wallet SHALL update immediately after:

- Invoice Approval
- Receipt
- Payment
- Return
- Journal Entry

---

## ADR-334

**Status:** APPROVED

### Title

Audit Protection

### Rule

Wallet history SHALL NEVER be deleted.

Historical balances SHALL remain available.

---

## ADR-335

**Status:** APPROVED

### Title

Currency Support

### Rule

Financial Wallet SHALL support future Multi-Currency implementation.

Current Version uses one Base Currency only.

---

## ADR-336

**Status:** APPROVED

### Title

Partner Dashboard

### Rule

Every Business Partner SHALL expose Wallet Summary inside Partner Dashboard.

---

## ADR-337

**Status:** APPROVED

### Title

Reporting

### Rule

Reporting Engine SHALL retrieve partner financial statistics directly from Financial Wallet.

---

## ADR-338

**Status:** APPROVED

### Title

Performance

### Rule

Financial Wallet SHALL be optimized for fast balance retrieval without recalculating transaction history.

---

## ADR-339

**Status:** APPROVED

### Title

Future CRM Compatibility

### Rule

Financial Wallet SHALL expose reusable APIs for future CRM and Loyalty modules.

---

## ADR-340

**Status:** APPROVED

### Title

Wallet Engine

### Rule

Financial Wallet SHALL operate only through the SmartPOS Transaction Engine.

Manual modification is prohibited.
---

## ADR-341

**Status:** APPROVED

### Title

Business Partner Timeline

### Rule

Every Business Partner SHALL have a unified chronological Timeline.

The Timeline SHALL display all financial and operational activities.

---

## ADR-342

**Status:** APPROVED

### Title

Timeline Events

### Rule

Timeline SHALL include:

- Sales Invoice
- Purchase Invoice
- Sales Return
- Purchase Return
- Receipt Voucher
- Payment Voucher
- Journal Entry
- Opening Balance
- Inventory Adjustment (when applicable)

---

## ADR-343

**Status:** APPROVED

### Title

Chronological Order

### Rule

Timeline SHALL always be sorted by:

- Date
- Time

Newest entries MAY appear first according to user preference.

---

## ADR-344

**Status:** APPROVED

### Title

Timeline Details

### Rule

Every Timeline Event SHALL display:

- Date
- Time
- Document Type
- Document Number
- Debit
- Credit
- Running Balance

---

## ADR-345

**Status:** APPROVED

### Title

Timeline Filters

### Rule

Timeline SHALL support filtering by:

- All
- Sales
- Purchases
- Returns
- Receipts
- Payments
- Journal Entries

---

## ADR-346

**Status:** APPROVED

### Title

Timeline Search

### Rule

Timeline SHALL support searching by:

- Document Number
- Amount
- Date
- Notes

---

## ADR-347

**Status:** APPROVED

### Title

Timeline Navigation

### Rule

Selecting any Timeline Event SHALL open the original document directly.

---

## ADR-348

**Status:** APPROVED

### Title

Timeline Security

### Rule

Timeline visibility SHALL respect user permissions.

Unauthorized document types SHALL remain hidden.

---

## ADR-349

**Status:** APPROVED

### Title

Timeline Performance

### Rule

Timeline SHALL use lazy loading and pagination.

Large histories SHALL NOT affect system performance.

---

## ADR-350

**Status:** APPROVED

### Title

Unified Activity History

### Rule

Timeline SHALL become the primary activity history for every Business Partner.

Separate history windows SHALL NOT be required.
---

## ADR-351

**Status:** APPROVED

### Title

Business Partner Dashboard

### Rule

Every Business Partner SHALL have a Dashboard.

The Dashboard SHALL display live business indicators.

---

## ADR-352

**Status:** APPROVED

### Title

Current Financial Summary

### Rule

The Dashboard SHALL display:

- Current Balance
- Credit Limit
- Available Credit
- Outstanding Balance

---

## ADR-353

**Status:** APPROVED

### Title

Sales Statistics

### Rule

The Dashboard SHALL display:

- Total Sales
- Number of Sales Invoices
- Average Invoice Value
- Highest Invoice Value

---

## ADR-354

**Status:** APPROVED

### Title

Purchase Statistics

### Rule

For Suppliers or Customer/Suppliers the Dashboard SHALL display:

- Total Purchases
- Purchase Count
- Average Purchase Value

---

## ADR-355

**Status:** APPROVED

### Title

Payment Statistics

### Rule

The Dashboard SHALL display:

- Total Receipts
- Total Payments
- Last Receipt
- Last Payment

---

## ADR-356

**Status:** APPROVED

### Title

Activity Summary

### Rule

The Dashboard SHALL display:

- Last Transaction Date
- Last Invoice
- Last Return
- Last Financial Movement

---

## ADR-357

**Status:** APPROVED

### Title

Business Status

### Rule

The Dashboard SHALL display:

- Active
- Suspended
- Archived

Customer status SHALL always be visible.

---

## ADR-358

**Status:** APPROVED

### Title

Quick Actions

### Rule

The Dashboard SHALL provide quick actions:

- New Sale
- New Purchase
- Receipt Voucher
- Payment Voucher
- Statement
- Timeline

---

## ADR-359

**Status:** APPROVED

### Title

Live Refresh

### Rule

Partner Dashboard SHALL update automatically after every approved transaction.

No manual refresh is required.

---

## ADR-360

**Status:** APPROVED

### Title

Dashboard Source

### Rule

Partner Dashboard SHALL retrieve all values from:

- Financial Wallet
- Transaction Engine
- Reporting Engine

Dashboard SHALL never calculate values independently.
---

## ADR-361

**Status:** APPROVED

### Title

Business Partner Rating

### Rule

Every Business Partner SHALL have a dynamic Rating calculated automatically by the system.

Manual modification is prohibited.

---

## ADR-362

**Status:** APPROVED

### Title

Rating Factors

### Rule

Partner Rating SHALL be calculated using configurable weighted factors including:

- Total Sales
- Total Purchases
- Payment Regularity
- Outstanding Balance
- Return Rate
- Business Duration
- Transaction Frequency

---

## ADR-363

**Status:** APPROVED

### Title

Automatic Recalculation

### Rule

Partner Rating SHALL be recalculated automatically after every approved financial transaction.

---

## ADR-364

**Status:** APPROVED

### Title

Rating Levels

### Rule

Default Rating Levels SHALL be:

★★★★★ VIP

★★★★ Excellent

★★★ Good

★★ Average

★ Low

Rating thresholds SHALL be configurable.

---

## ADR-365

**Status:** APPROVED

### Title

Dashboard Display

### Rule

Partner Rating SHALL be displayed inside Partner Dashboard.

---

## ADR-366

**Status:** APPROVED

### Title

Report Integration

### Rule

Reporting Engine SHALL support filtering and sorting by Partner Rating.

---

## ADR-367

**Status:** APPROVED

### Title

Future CRM Integration

### Rule

Partner Rating SHALL be available for future CRM features.

---

## ADR-368

**Status:** APPROVED

### Title

Future Loyalty Integration

### Rule

Partner Rating SHALL be available for future Loyalty Programs.

---

## ADR-369

**Status:** APPROVED

### Title

Future Offer Integration

### Rule

Offer Engine SHALL be capable of targeting customers according to Partner Rating.

---

## ADR-370

**Status:** APPROVED

### Title

Rating Source

### Rule

Partner Rating SHALL be calculated exclusively from Financial Wallet and Transaction Engine data.

Manual override is prohibited.
---

## ADR-371

**Status:** APPROVED

### Title

Universal Activity Center

### Rule

The system SHALL implement one centralized Universal Activity Center.

All modules SHALL record activities through this engine.

---

## ADR-372

**Status:** APPROVED

### Title

Tracked Activities

### Rule

The Activity Center SHALL record all important business events including:

- Login
- Logout
- Sales
- Purchases
- Returns
- Receipts
- Payments
- Inventory Count
- Inventory Adjustment
- Price Changes
- Product Creation
- Product Update
- Partner Creation
- Partner Update
- Cash Shift Open
- Cash Shift Close
- License Operations
- Backup
- Archive
- Opening New Fiscal Year
- Balance Migration
- Database Maintenance

---

## ADR-373

**Status:** APPROVED

### Title

Activity Record Structure

### Rule

Every activity SHALL contain:

- Activity ID
- Timestamp
- User ID
- Device ID
- Branch ID
- Module
- Action
- Entity Type
- Entity ID
- Description

---

## ADR-374

**Status:** APPROVED

### Title

Activity Severity

### Rule

Activities SHALL support severity classification:

- Information
- Warning
- Critical

---

## ADR-375

**Status:** APPROVED

### Title

Activity Categories

### Rule

Activities SHALL support categories:

- Security
- Sales
- Purchasing
- Inventory
- Accounting
- Administration
- Maintenance
- Developer

---

## ADR-376

**Status:** APPROVED

### Title

Filtering

### Rule

Activity Center SHALL support filtering by:

- Date
- User
- Module
- Category
- Severity
- Branch

---

## ADR-377

**Status:** APPROVED

### Title

Search

### Rule

Activity Center SHALL support searching by:

- Document Number
- Product
- Customer
- Supplier
- User
- Notes

---

## ADR-378

**Status:** APPROVED

### Title

Audit Protection

### Rule

Activity records SHALL NEVER be edited.

Activity records SHALL NEVER be deleted.

---

## ADR-379

**Status:** APPROVED

### Title

Retention

### Rule

Activity records SHALL remain permanently available unless archived by Developer Center.

---

## ADR-380

**Status:** APPROVED

### Title

Timeline Integration

### Rule

Business Partner Timeline SHALL retrieve partner activities from the Universal Activity Center whenever applicable.

---

## ADR-381

**Status:** APPROVED

### Title

Developer Integration

### Rule

Developer Center SHALL use Universal Activity Center for maintenance logs.

No separate maintenance log engine shall exist.

---

## ADR-382

**Status:** APPROVED

### Title

Security Integration

### Rule

Authentication Engine SHALL automatically log:

- Login
- Logout
- Failed Login
- Permission Denied

through Universal Activity Center.

---

## ADR-383

**Status:** APPROVED

### Title

Performance

### Rule

Universal Activity Center SHALL use indexed storage and pagination.

Large activity history SHALL NOT affect application performance.

---

## ADR-384

**Status:** APPROVED

### Title

Unified Audit Engine

### Rule

Universal Activity Center SHALL become the single audit source for the entire SmartPOS ERP system.

No module shall implement its own independent audit log.
---

## ADR-385

**Status:** APPROVED

### Title

Developer Ownership of Activity Records

### Rule

Only Developer Center may archive or permanently delete Activity Center records.

No operational user, including Administrator, may perform these actions.

---

## ADR-386

**Status:** APPROVED

### Title

Archive Before Delete

### Rule

Activity records SHALL NOT be permanently deleted before being archived.

Archive operation is mandatory.

---

## ADR-387

**Status:** APPROVED

### Title

Mandatory Backup

### Rule

Developer Center SHALL create a verified backup before any archive or deletion process.

If backup creation fails, the operation SHALL be cancelled.

---

## ADR-388

**Status:** APPROVED

### Title

Archive Package

### Rule

Archived Activity records SHALL be stored inside an encrypted archive package.

The archive SHALL include:

- Activity Records
- Metadata
- Archive Date
- Archive Version
- Company Identifier

---

## ADR-389

**Status:** APPROVED

### Title

Restore Support

### Rule

Developer Center SHALL support restoring archived Activity records without affecting current operational data.

---

## ADR-390

**Status:** APPROVED

### Title

Developer Audit

### Rule

Every archive or deletion performed by Developer Center SHALL generate a permanent Developer Audit Record containing:

- Developer ID
- Date
- Time
- Company
- Archive Size
- Deleted Records Count
- Archive File Name
- Restore Identifier

Developer Audit Records SHALL NEVER be deleted automatically.
---

## ADR-391

**Status:** APPROVED

### Title

Universal Retention Policy

### Rule

All historical records within SmartPOS ERP SHALL follow the Universal Retention Policy.

---

## ADR-392

**Status:** APPROVED

### Title

Historical Records Protection

### Rule

Historical records SHALL NOT be editable.

Historical records SHALL NOT be deleted by any operational user.

---

## ADR-393

**Status:** APPROVED

### Title

Developer Exclusive Authority

### Rule

Only Developer Center SHALL have authority to:

- Archive historical records.
- Restore archived records.
- Permanently delete archived records.

No Administrator or Company Owner SHALL have these permissions.

---

## ADR-394

**Status:** APPROVED

### Title

Archive Before Delete

### Rule

Permanent deletion SHALL NEVER occur directly.

The workflow SHALL always be:

1. Create Verified Backup.
2. Archive Data.
3. Verify Archive Integrity.
4. Permanently Delete Archived Data (Optional).

---

## ADR-395

**Status:** APPROVED

### Title

Mandatory Backup

### Rule

Every archive or deletion operation SHALL require a successful verified backup.

Failure to create backup SHALL abort the operation.

---

## ADR-396

**Status:** APPROVED

### Title

Developer Audit Trail

### Rule

Every archive, restore or delete operation SHALL generate a permanent Developer Audit Record.

Developer Audit Records SHALL NEVER be deleted automatically.

---

## ADR-397

**Status:** APPROVED

### Title

Universal Scope

### Rule

The Universal Retention Policy SHALL apply to all historical records including but not limited to:

- Sales Journals
- Purchase Journals
- Inventory Transactions
- Financial Transactions
- Business Partner Timeline
- Universal Activity Center
- Maintenance Logs
- Backup Logs
- License Logs
- Security Logs
- Future historical modules

---

## ADR-398

**Status:** APPROVED

### Title

Future Compatibility

### Rule

Any future module containing historical records SHALL automatically inherit the Universal Retention Policy unless explicitly overridden by a newer ADR.

---

## ADR-399

**Status:** APPROVED

### Title

Central Transaction Engine

### Rule

The SmartPOS ERP system SHALL implement one centralized Transaction Engine.

All business operations SHALL be executed exclusively through this engine.

No module SHALL modify business data directly.

The Transaction Engine SHALL become the single execution layer responsible for maintaining business consistency across the entire ERP.

Every approved transaction SHALL be processed in the following order:

1. Validate Business Rules.
2. Execute Database Transaction.
3. Update Inventory Engine (when applicable).
4. Update Accounting Engine.
5. Update Business Partner Financial Wallet.
6. Register Universal Activity Center event.
7. Refresh Reporting Engine data.
8. Trigger Notification Engine events.
9. Write Audit Records.
10. Commit Transaction.

If any step fails:

- The entire transaction SHALL be rolled back.
- No partial updates SHALL remain.
- Database consistency SHALL be preserved.

All future modules SHALL integrate with the Transaction Engine.

Examples include:

- Sales
- Purchases
- Inventory
- Returns
- Cash Management
- Accounting
- Manufacturing
- CRM
- Loyalty
- E-Commerce
- Future Modules

The Transaction Engine SHALL become the core execution layer of SmartPOS ERP.