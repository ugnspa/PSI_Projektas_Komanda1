# Architecture:
The project uses ASP.NET MVC architecture:

![Working-of-MVC-1024x686](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/cb46d63e-1b49-450d-8ae1-3dbb2d9a53cb)


The architecture consists of:
<ul>
<li>
  Views - where the user interacts. They are kept in the Views folder.
  </li>
<li>
  Controller - processes requests and sends responses to the view. They are kept in the Controllers folder. Each controller must have "Controller" postfix.
  </li>
<li>
  Model - middleware for handling database entries (objects). They are kept in the models folder.
  </li>
<li>
  Repository - handles reading and writing to the database They are kept in the Repository folder. Each model has its own repository. Each repository file has a "Repo" postfix.
  </li>
  </ul>
  
Tools used:
<ul>
  <li>C# - programming (back-end)</li>
  <li>JavaScript(HTML and CSS) for front-end</li>
  <li>GIT - version control</li>
</ul>

Technologies used:
<ul>
  <li>ASP.NET MVC (through VS 2022) - web application framework</li>
  <li>MySQL (phpMyAdmin) database</li>
  <li>PayPal API for handling payments</li>
</ul>
  
# How to run the project:

To run the project, the users must have a MySql database. The database can be hosted on the cloud or locally.
An example database dump is provided in this repository under the name <i>shopdb.sql</i>

To host the database locally, we recommend to use XAAMP.

## How to launch the database locally

In this example we use a phpMyAdmin database management tool.

Launch XAAMP Control Panel and start Apache and MySql services:
    
![image](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/0df2e879-f245-4c79-9c97-cb42cb747cab)
    
The phpMyAdmin page will be accessible at: [localhost/phpmyadmin/](http://localhost/phpmyadmin)

After logging in press <i>New</i> and enter the database name <i>shopdb</i>

![image](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/849f3a72-135e-4234-a765-dad3a59d0a0f)

After hitting <i>Create</i> a new database will appear on the left.

Press on the <i>shopdb</i> database, go to <i>Import</i> and import the <i>shopdb.sql</i> file which can be found in this repository.


## Adding database credentials

! --- This part can be skipped if the database was set up following our example above
In the appsetings.json, at the "DbConnStr" line add your database login credentials:

![image](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/40f7903d-e9f8-46d9-aec6-f7d08fffc9d6)

Data source - database IP adress.
port - database PORT.
Initial Catalog - database name
User Id - username
Password - user password

## Adding PayPal API credentials
In the appsettings.json file you must also add your PayPal API credentials, so that the item ordering works.

![image](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/4194b653-ec3b-4701-a903-fb64b66f5c43)

## Launching the project

The project can be built and launched through VS 2022 (requires ASP.NET and web development workload)
After the project is launched the web page will be accessible through [localhost:7259](https://localhost:7259)
