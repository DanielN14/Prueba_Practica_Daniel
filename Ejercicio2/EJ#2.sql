USE WideWorldImporters;

/*
	REQ01: Crear un query con el que se obtenga una lista de facturas entre el año 2013 
	y 2015 en donde se muestre el id de la factura, el id del cliente, nombre del cliente,
	el nombre del método de la entrega, el límite de crédito (en caso de que sea nulo, 
	mostrar valor -1) y el nombre del vendedor.
*/

SELECT 
	i.InvoiceID AS 'IdFactura', 
	i.CustomerID AS 'IdCliente', 
	c.CustomerName AS 'NombreCliente', 
	p.DeliveryMethodName AS 'NombreMetodoEntrega',
	ISNULL(c.CreditLimit, -1) AS 'LimiteCredito',
	pe.FullName AS 'NombreVendedor'
FROM Sales.Invoices i
INNER JOIN Sales.Customers c ON i.CustomerID = c.CustomerID
INNER JOIN Application.DeliveryMethods p ON i.DeliveryMethodID = p.DeliveryMethodID
INNER JOIN Application.People pe ON i.SalespersonPersonID = pe.PersonID
WHERE YEAR(i.InvoiceDate) BETWEEN 2013 AND 2015;

/*
	REQ02: Crear un query con el que se obtenga la cantidad de facturas por cliente,
	ordenado por esta cantidad, más una columna que indique el consecutivo basado en
	esa cantidad; esta consulta como resultado deberá tener 4 columnas: el id del cliente,
	nombre del cliente, total facturas, orden.
*/

SELECT 
	i.CustomerID AS 'Id Cliente', 
	c.CustomerName AS 'Nombre Cliente', 
	COUNT(*) AS 'Total Facturas',
	ROW_NUMBER() OVER (ORDER BY COUNT(i.InvoiceID) DESC) AS Orden
FROM SALES.Invoices i
INNER JOIN SALES.Customers c ON i.CustomerID = c.CustomerID
GROUP BY i.CustomerID, c.CustomerName
ORDER BY 'Total Facturas' DESC;