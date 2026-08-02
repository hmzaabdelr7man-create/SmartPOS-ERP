# SmartPOS ERP Activity Center

Version: 1.0

Status: OFFICIAL

---

# Purpose

The Activity Center is the central timeline of SmartPOS ERP.

It records every important business event across the ERP.

It is designed for:

- Tracking
- Monitoring
- Auditing
- Troubleshooting
- User Accountability

---

# Golden Rule

Every important operation SHALL create one Activity Record.

No module may bypass the Activity Center.

---

# Recorded Events

The Activity Center SHALL record:

## Sales

- New Sale
- Sale Return
- Invoice Cancellation
- Invoice Editing

---

## Purchasing

- Purchase
- Purchase Return
- Receiving

---

## Inventory

- Inventory Count
- Stock Adjustment
- Product Creation
- Product Update
- Product Archive
- Product Restore

---

## Business Partners

- Customer Created
- Supplier Created
- Wallet Movement
- Payment
- Receipt
- Archive
- Restore

---

## Accounting

- Journal Posted
- Journal Reversed
- Fiscal Closing

---

## System

- Login
- Logout
- Permission Changes
- Backup
- Restore
- Settings Modification

---

# Activity Record Structure

Each Activity SHALL contain:

- Activity ID
- Transaction ID
- Module
- Operation
- User
- Device
- Date
- Time
- Description
- Reference Number

---

# Search

The Activity Center SHALL support searching by:

- Date
- User
- Module
- Operation
- Transaction ID
- Customer
- Supplier
- Invoice Number

---

# Filtering

The Activity Center SHALL support filtering by:

- Module
- User
- Date Range
- Operation Type

---

# History Integrity

Activity Records SHALL NEVER be edited.

Activity Records SHALL NEVER be deleted by ordinary users.

Developer Mode MAY archive activities.

---

# Relationship

Every Activity SHALL reference:

- Inventory Logs
- Accounting Journals
- Wallet History
- Reports

using the same Transaction ID.

---

# Performance

The Activity Center SHALL use pagination.

It SHALL NOT load all records at once.

---

# Developer Rule

Developer Mode MAY:

- Archive Activities
- Restore Archived Activities
- Permanently Purge Archived Activities

Historical integrity SHALL always be preserved.

---

# Architecture Rule

Every future module SHALL automatically integrate with the Activity Center.

Creating a module without Activity logging is forbidden.
