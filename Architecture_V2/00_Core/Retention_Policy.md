# SmartPOS ERP Retention Policy

Version: 1.0

Status: OFFICIAL

---

# Purpose

The Retention Policy defines how SmartPOS ERP preserves historical information while allowing operational cleanup.

Historical integrity SHALL always have priority over storage optimization.

---

# Fundamental Rule

Deleting a business entity SHALL NEVER delete its historical transactions.

Examples:

Deleting a Customer SHALL NOT delete:

- Sales
- Receipts
- Wallet History
- Accounting Journals
- Activity Records

Deleting a Supplier SHALL NOT delete:

- Purchases
- Payments
- Accounting Journals
- Activity Records

Deleting a Product SHALL NOT delete:

- Sales History
- Purchase History
- Inventory History
- Barcode History

---

# Deletion Types

SmartPOS supports three deletion levels.

## Level 1

Soft Delete

The record becomes hidden.

It remains recoverable.

Historical references remain intact.

---

## Level 2

Archive

The record is moved out of operational lists.

It remains searchable.

It remains printable.

It remains recoverable.

---

## Level 3

Permanent Purge

Available ONLY in Developer Mode.

Requires confirmation.

Requires administrator permission.

Requires logging.

---

# Archivable Records

The following records MAY be archived:

- Customers
- Suppliers
- Products
- Receipts
- Payments
- Activities
- Notifications
- Daily Sales Journals
- Cash Shifts

---

# Non-Archivable Records

The following records SHALL NEVER be physically removed automatically:

- Accounting Journals
- Fiscal Closing Records
- Transaction IDs
- Audit Logs

---

# Restore Policy

Archived records SHALL support full restoration.

Restoration SHALL preserve:

- Original ID
- Original Dates
- Relationships
- Transaction References

---

# Developer Mode

Developer Mode MAY:

- Purge Archived Records
- Rebuild Archive Indexes
- Verify Referential Integrity
- Export Archive
- Restore Archive

Developer Mode SHALL NOT modify historical accounting balances.

---

# Retention by Module

## Inventory

Products may be archived.

Inventory history SHALL remain forever.

---

## Sales

Invoices SHALL remain permanently.

Daily Journals MAY be archived.

---

## Purchasing

Purchases SHALL remain permanently.

---

## Accounting

Accounting Journals SHALL NEVER be deleted.

---

## Business Partners

Customers and Suppliers MAY be archived.

Historical transactions SHALL remain available.

---

# Search

Archived records SHALL remain searchable.

Search results SHALL clearly identify archived status.

---

# Audit

Every archive, restore, and purge operation SHALL create:

- Activity Record
- Audit Record

Developer identity SHALL always be recorded.

---

# Architecture Rule

Retention Policy applies to every module inside SmartPOS ERP.

No module may implement its own retention mechanism.
