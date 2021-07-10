CREATE TABLE Producto(
   idProducto NUMBER(9),
   Producto VARCHAR2(50),   
   CONSTRAINT Producto_pk PRIMARY KEY(idProducto),
);

CREATE TABLE Facturas(
   IdFactura NUMBER(9),
   NumeroFactura NUMBER(9),
   Fecha DATE DEFAULT SYSDATE
   TipodePago VARCHAR2(9),
   DocumentoCliente VARCHAR2(12),
   NombreCliente VARCHAR2(50),
   idProducto NUMBER(9)
   Subtotal NUMBER(6,8),
   Descuento NUMBER(9),
   IVA NUMBER(9),
   TotalDescuento NUMBER(6,8),
   TotalImpuesto NUMBER(6,8),
   Total NUMBER(6,8),
   CONSTRAINT Facturas_pk PRIMARY KEY(IdFactura),
   CONSTRAINT fk_idProducto FOREIGN KEY (idProducto) REFERENCES Producto (idProducto)
);






