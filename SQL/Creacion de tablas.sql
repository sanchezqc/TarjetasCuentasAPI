-- Crear tabla Clientes
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL
);

-- Crear tabla Cuentas
CREATE TABLE Cuentas (
    Id INT PRIMARY KEY IDENTITY,
    NumeroCuenta VARCHAR(20) NOT NULL,
    IdCliente INT NOT NULL,
    Moneda VARCHAR(10) NOT NULL,
    Estado INT NOT NULL,
    Tipo INT NOT NULL,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(Id) ON DELETE CASCADE
);

-- Crear tabla Tarjetas
CREATE TABLE Tarjetas (
    Id INT PRIMARY KEY IDENTITY,
    Numero VARCHAR(16) NOT NULL,
    FechaVencimiento DATE NOT NULL,
    Emisor VARCHAR(100) NOT NULL,
    IdCliente INT NOT NULL,
    Estado INT  NOT NULL,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(Id) ON DELETE CASCADE
);