Вопрос 9
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

Ответ
Если имеем три таблицы:
1. Products с полями ProductID, ProductName
2. Categories с полями CategoryID, CategoryName
3. Map с полями ProductID, CategoryID

то получим:
SELECT DISTINCT Products.ProductName, newMap.CategoryName 
FROM Progucts 
LEFT JOIN (SELECT Map.ProductID, Map.CategoryID, Categories.CategoryName FROM Map INNER JOIN Categories ON Categories.CategoryID=Map.CategoryID) newMap 
ON Products.ProductID=newMap.ProductID 
ORDER By Products.ProductName ASC