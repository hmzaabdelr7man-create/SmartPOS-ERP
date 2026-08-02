# SmartPOS ERP Universal Policies

Version: 1.0

Status: OFFICIAL

---

# Purpose

This document defines the universal policies that apply across the entire SmartPOS ERP.

These policies override module-specific behavior.

No module may violate these policies.

---

# Universal Principles

The following principles are mandatory:

- Consistency before speed
- Data is never silently lost
- Every important action is traceable
- Every financial movement is auditable
- Historical integrity has priority
- User actions are accountable
- System behavior must be predictable

---

# Universal Transaction Policy

Every business operation SHALL pass through the Transaction Engine.

Direct modification of business data is forbidden.

---

# Universal Activity Policy

Every important operation SHALL create an Activity Center record.

Examples:

- Sales
- Purchases
- Returns
- Inventory Adjustments
- Payments
- Receipts
- User Management
- System Configuration

Activity records SHALL NOT be editable.

---

# Universal Audit Policy

Every financial and inventory transaction SHALL create an Audit Record.

Audit Records SHALL contain:

- Transaction ID
- Date & Time
- User
- Device
- Module
- Operation
- Before Value
- After Value

Audit Records SHALL NEVER be deleted by ordinary users.

---

# Universal Notification Policy

Notifications SHALL be generated only by the Notification Engine.

Modules SHALL NEVER send notifications directly.

Notification examples:

- Low Stock
- Purchase Received
- Invoice Cancelled
- Cash Shift Closed
- Backup Failed

---

# Universal Retention Policy

Deleting business records SHALL NOT remove historical transactions.

Example:

Deleting:

- Customer
- Supplier
- Product

SHALL NOT delete:

- Sales
- Purchases
- Payments
- Receipts
- Inventory History
- Accounting Journals

Historical integrity SHALL always be preserved.

---

# Universal Archive Policy

Large operational tables MAY be archived.

Archived data SHALL remain searchable.

Archived data SHALL remain printable.

Archived data SHALL NOT affect accounting integrity.

Developer Mode MAY permanently purge archived records after user confirmation.

---

# Universal Soft Delete Policy

Business entities SHALL use Soft Delete by default.

Soft Deleted records:

- Hidden from normal users
- Preserved historically
- Recoverable

Permanent deletion SHALL require Developer Mode.

---

# Universal Developer Policy

Developer Mode may:

- Purge Archives
- Restore Archived Data
- Rebuild Indexes
- Database Maintenance
- Integrity Verification

Developer Mode SHALL NOT modify historical financial records.

---

# Universal Security Policy

Permissions SHALL always override UI visibility.

Hidden screens SHALL remain inaccessible even if opened manually.

---

# Universal Multi Device Policy

Version 1 supports:

- Single Branch
- Multiple Local Devices

All devices SHALL share the same database.

Transaction conflicts SHALL be handled by the Transaction Engine.

---

# Universal Printing Policy

Every printable document SHALL support:

- Thermal Printer
- A4 Printer (future)
- PDF Export

Barcode generation SHALL use the centralized Barcode Library.

---

# Universal Barcode Policy

Barcode generation SHALL be centralized.

No module may implement its own barcode generator.

Supported initially:

- Code128
- EAN13

Future versions may add:

- QR Code
- DataMatrix

---

# Universal Reporting Policy

Reports SHALL NEVER calculate directly from UI data.

Reports SHALL always use Reporting Engine.

---

# Universal Performance Policy

The ERP SHALL prioritize:

1. Data Integrity
2. Accounting Integrity
3. Inventory Integrity
4. Performance

Performance SHALL NEVER compromise correctness.

---

# Architecture Rule

Every future module SHALL automatically inherit these policies.

No module-specific implementation may contradict this document.
