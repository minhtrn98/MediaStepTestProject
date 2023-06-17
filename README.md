# Sample shop project

- Back-end: Asp.Net Web Api (.NET 6)
- Front-end: React
- Database: Sql Server Express

## Schema
```
> Customers
| ------------- |:-------------:|
| Id            | int           |
| FullName      | nvarchar(200) |
| Email         | nvarchar(200) |
| DoB           | datetime2     |
```
```
> Products
| ------------- |:-------------:|
| Id            | int           |
| Name          | nvarchar(1000)|
| Price         | decimal(18,2) |
| ShopId        | int           |
```
```
> Shops
| ------------- |:-------------:|
| Id            | int           |
| Name          | nvarchar(200) |
| Location      | nvarchar(MAX) |
```
```
> CustomerProducts
| ------------- |:-------------:|
| CustomerId    | int           |
| ProductId     | int           |
| Quantity      | int           |
```

## Phân quyền

### User Admin: { Email: admin@gmail.com }

#### Chức năng:

1. View/Add customer
1. View/Add shop
1. View/Search/Add product
1. View customer buy product at shop

### Customer: Login using customer email

#### Chức năng:

1. View/Search/Buy product
