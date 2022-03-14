create database bdteste;
use bdteste;
create table tabelateste
(numCli int auto_increment,
nome varchar(50) null,
endereco varchar (50) null,
salario decimal (11,2) null,
primary key(numCli));