# AuthServer

## Demo project of my REST api auth server

## 1. Requrements

* `dotnet` CLI

  to build backend

Optional:

* `docker`

  to run database
  
## 2. Setup

> This project needs some security keys to be set up so I wrote simple bash script to generate all necessary data for project

To run setup script just execute 

On linux in bash

```shell
git clone https://github.com/FileBin/InnoShop
cd InnoShop

./setup.sh

./publish.sh
```


On windows use powershell or if doesn't work use git bash and execute **linux** commands

```ps1
git clone https://github.com/FileBin/InnoShop
cd InnoShop

.\setup.ps1

.\publish.bat
```

And input all necessary data (or use \[default\] option if available)

## 3. How to run:
* ### From command line
  To run application execute in terminal

  ```shell
  docker compose up
  ```

  Or 

  ```shell
  docker compose up -d
  ```

  After site starts you can login as admin (login: admin, password is in file .private/cache.sh)

## 4. Using VSCode (for devs)
  In command pallette choose `Tasks: Run Task` and choose `Start All`
