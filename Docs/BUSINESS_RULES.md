# SmartPOS ERP
# BUSINESS RULES

Version: 1.0

---

# PURPOSE

This document defines all official business rules of SmartPOS ERP.

Business Rules are the highest authority.

Implementation MUST follow Business Rules.

Never implement behavior that conflicts with this document.

If any requested feature conflicts with these rules:

STOP

Ask the user.

Never guess.

---

# CORE PHILOSOPHY

SmartPOS ERP is designed for:

- Supermarkets
- Grocery Stores
- Retail Shops
- Wholesale
- Distribution

The system priorities are:

1. Speed
2. Stability
3. Accuracy
4. Data Integrity
5. Simplicity

---

# IMMUTABLE RULES

The following records are immutable after approval:

- Sales Invoice
- Purchase Invoice
- Sales Return
- Purchase Return
- Journal Entry
- Inventory Movement

Historical records MUST NEVER be edited or deleted.

Corrections are performed using new transactions only.

---

# INVENTORY PRINCIPLE

Inventory is movement-based.

Inventory quantity is calculated from transactions.

Manual quantity editing is prohibited except through Inventory Adjustment.

---

# ACCOUNTING PRINCIPLE

Every financial operation generates accounting entries.

No financial operation exists without accounting impact.

The system follows Full Double Entry Accounting.

---

# BARCODE PRINCIPLE

Product Code:

8 digits

Scale Barcode:

13 digits

First 8 digits:

Original Product Code

Last 5 digits:

Weight in grams

The system calculates price automatically.

---

# UNIT PRINCIPLE

Inventory is always stored using Base Unit.

Every transaction converts automatically.

Supported in:

Sales

Sales Returns

Purchases

Purchase Returns

Transfers

Inventory Adjustment

---

# REPORT PRINCIPLE

Reports are read-only.

Reports never modify data.

Reports support:

- Print
- PDF
- Excel
- CSV
- Share

Historical reports never change.

---

# SECURITY PRINCIPLE

Permissions are role-based.

Developer Center is hidden from all customer accounts.

Only Developer Account may access Developer Center.

---
# TRANSACTION ENGINE

Every business operation MUST execute through the SmartPOS Transaction Engine.

The Transaction Engine is responsible for:

- Validation
- Permission Check
- Inventory Update
- Accounting Entry
- Customer Balance
- Supplier Balance
- Cash Box Update
- Audit Log
- Auto Save
- Recovery Snapshot
- Reporting Update

No UI screen may perform these operations directly.
END OF DOCUMENT
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