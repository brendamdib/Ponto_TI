--script para criação das tabelas do banco de dados
create table tbl_colab(
id_colab int identity(1,1) primary key,
usr_colab varchar(20) not null,
psw_colab varchar(10) not null,
grplogin_colab int not null,
nome_colab varchar(90) not null,
cpf_colab varchar(14) not null,
status_colab int not null,
regional_colab int not null) 

create table tbl_ponto(
id_colab_ponto int primary key,
data_ponto datetime not null,
id_acao_ponto int not null,
ip_ponto varchar(20)) 

create table tbl_acao(
id_acao int primary key,
nome_acao varchar(20)) 

create table tbl_regional(
id_regional int primary key,
nome_regional varchar(20)) 

create table tbl_grupoacesso(
id_grupoacesso int primary key,
nome_grupoacesso varchar(20)) 