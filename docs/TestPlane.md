# Test Analysis: demoShop Application

### Content:

- [Introduction](Introduction.md)
- [Prerequisites](Prerequisites.md)
- [Guidelines](Guidelines.md)
- [Running Tests](Running-Tests.md)
- Test Plane

---

## Introduction

This document contains a test analysis for the newly delivered demoShop application.
The goal is to ensure the quality of the shopping process and the administrative section, which is used for inventory management.

---

## 1. Prioritization of Key Testing Areas

- **Priority 1 (Critical): Checkout process and purchase completion**
    - **Justification:** The main purpose of the demoShop is purchasing goods. If a customer cannot add a product to the cart and complete an order, the e-shop fails its basic function and loses revenue.
- **Priority 2 (High): Admin login and product management**
    - **Justification:** Without the ability to add, edit, or delete items, the e-shop has nothing to offer. A functional administration is essential for the proper operation of the store.
- **Priority 3 (Medium): Product detail view and navigation**
    - **Justification:** The customer must be able to find and view a product before deciding to buy it. This also includes searching and category filtering.

---

## 2. Testing Techniques and Test Levels

- **Test Levels:** Focus on **System Testing** and partially **User Acceptance Testing (UAT)**. The application will be tested from the perspective of the end customer and the administrator.
- **Testing Techniques:**
    - **Positive and Negative Testing:** This will verify that forms (like admin login and adding a product) accept valid data and correctly handle invalid inputs by showing appropriate error messages.
    - **Use Case Testing:** This will be applied to the main scenarios (checkout process, adding a product).
    - **Exploratory Testing:** Since the application has not yet gone through any QA, it is crucial to first manually explore the application and discover obvious User Interface (UI) bugs before automation.

## 3. Test Automation Proposal

For automation, I propose the following areas:

1.  **Critical business flows (End-to-End scenarios):** Especially the cart workflow and purchasing a product.
2.  **Repetitive administrative tasks:** Typically adding and verifying a new product.

**Justification:**
It makes the most sense to automate the core, everyday scenarios. Since these flows are the most important parts of the app, we have to test them every time we release a new version. Writing automated tests for this saves us hours of repetitive manual work and gives us peace of mind that new updates won't break the main shopping process. On the other hand, trying to automate checks for visual design or specific text is usually a waste of time—it's much faster to just check those manually.

