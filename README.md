![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/banner.gif)

---
 #  Backend
---
## Getting Started

#### <span style="color:purple">Step 1</span>

`https://github.com/veyselhim/HomeManagementSystem.git`

#### <span style="color:purple">**Step 2**</span>

###### Click and download [ApsisDemoScript.sql](https://easyupload.io/bvvvtv) file and create the database via a sql studio.

#### <span style="color:purple">**Step 3**</span>

###### Open the project and customize <span style="color:orange">**Connection String**</span> field in appsetting.json.

#### <span style="color:purple">**Step 4**</span>


> <span style="color:black">**Admin e-mail and password :**</span> veysel@gmail.com - 12345

> <span style="color:black">**Guest e-mail and password :**</span> veysel2@gmail.com - 12345

---

# 	Database Diagram
   
![diagram](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/DatabaseDiagram.png)
---
# Project Layers

- **Business**![folder](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/folder.png)
   - Abstract
   - BusinessAspects
   - Concrete
   - Constans
   - DependencyResolvers
   - Mapper
   - ServiceRepository
   - ValidationRules
- **Core** ![folder](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/folder.png)
  - Aspects
  - CrossCuttingConcerns
  - DependencyResolvers
   - EntityFramework
   - Extensions
   - MongoDbRepositories
   - Utilities
- **DataAccess**![folder](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/folder.png)
  - Abstract
  - Concrete
- **Entity** ![folder](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/folder.png)
   - Abstract
   - Concrete
   - DTOs
   - ApsisDemoWeb
- **ApsisDemo.Core_Test** ![folder](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/folder.png)
  - EfRepositoryTest

---

### Used Technologies ![tech](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/tech.png)

- **C#**
- **Microsoft Sql Server**
- **Mongo Db**

---

### Used Tools And Frameworks ![tools](https://github.com/veyselhim/HomeManagementSystem/blob/master/Backend/ApsisDemoScreenShots/tools.png)

- **Visual Studio 2019**

- **Postman**

- **Swagger**

- **Entity Framework & EF.Sql** - To use sql database

- **MongoDb Driver** - To use MongoDb

- **Autofac** - IOC container to manage lifecycle

- **AutoMapper** - To map objects belonging to dissimilar types

- **Fluent Validation** - Manages validation rules for our objects

  ---
  # FrontEnd
  ---
# Project Files

- **Components**![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/folder.png)
   - Apartment
   - Bill
   - BillPayment
   - Dues
   - DuesPayment
   - Admin-Dashboard
   - Home-page
   - User
   - User-Dashboard
   - Register
   - Login
   - Error-404
   - Message
- **Guards** ![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/guard.png)
  - *Admin Guard*
  - *Login Guard*
- **Interceptors**![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/folder.png)
  - *Auth Interceptor*
- **Layouts** ![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/folder.png)
   - *Admin-layout*
   - *Auth-layout*
   - *Main-layout*
- **Models** ![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/folder.png)
  - *Apartment*
  - *Bill*
  - *BillPayment*
  - *CardDocument*
  - *Dues*
  - *DuesPayment*
  - *Login*
  - *Message*
  - *Register*
  - *ResponseModels*
  - *Token*
  - *User*
- Pipes ![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/folder.png)
  - *Status YesNo pipe*
- Services ![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/folder.png)
  - *Apartment*
  - *Auth*
  - *Bill*
  - *BillPayment*
  - *CardDocument*
  - *Dues*
  - *DuesPayment*
  - *LocalStorage*
  - *Message*
  - *User*

---

### Used Tools And Frameworks ![github](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/tools.png)

- **Bootstrap 5.0**
- **Semantic UI**
- **Ngx Toastr**

----

## Images And Descriptions



### HOME

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/homepage.gif)



###### On this page, the user logs into the system. When the "Giriş Yap"button is clicked, it is directed to the login screen.

![login](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/login.png)



###### If the logged in user has admin authority, he is directed to the admin dashboard.If not, it will be redirected to the user dashboard. 

#### User login with admin authority

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/adminlogin.gif)

#### User login with non authority

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/userlogin.gif)

###### If non-admin user tries to go to admin page they will receive a "You do not have permission" warning and the guard will be activated.

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/adminPermission.gif)

###### Admin deletes users, updates and can go to detail screen.

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/userDelete.gif)



###### Admin assigns users to apartments.

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/apartmentadd.png)

###### Admin assigns bill and dues to users

###### ![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/duesadd.png)

###### Apartment details of users on site

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/apartments.png)

###### User Detail

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/userdetail.gif)

###### If the user goes to the home page after logging in, the welcome button is created.If he logs out, the login button will appear again.

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/userWelcome.gif)

User can add and remove new cards.

###### ![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/cardoperations.gif)

###### User can send message to admin

###### ![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/message.png)

###### Payment is made with the card of the logged in user

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/payment.gif)

###### The localStorage is cleared when the user logs out

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/userLogout.gif)

###### If the user types the wrong address in the search bar, he will get an error 404.

![Alt Text](https://github.com/veyselhim/HomeManagementSystem/blob/master/Frontend/ApsisDemoScreenShots/error.gif)


