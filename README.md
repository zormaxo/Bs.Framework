
# Monolithic Framework Example

Monolithic software is designed to be self-contained. The software's components or functions are tightly coupled rather than loosely coupled, as in modular software programs. In a monolithic architecture, each element and its associated components must all be present for code to be executed or compiled and for the software to run.

This framework depicts a sample traditional three-layer architecture, which divides the project into three layers: User interface layer, business layer, and data (database) layer, where we separate UI, logic, and data into three divisions.

## Some Features

1.  Transaction management. If an exception is thrown, the database transaction will be rolled back.
2.  NLOG logger implementation
3.  Exception logging
4.  Supports soft deletion
