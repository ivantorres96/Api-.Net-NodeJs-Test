const sql = require('mssql');

// Configuración de la conexión a la base de datos
const config = {
    user: 'NombreUsuario',
    password: 'Contraseña',
    server: 'localhost',
    database: 'NombreBaseDatos',
    options: {
        encrypt: true,
        trustServerCertificate: true
    }
};

// Función para obtener la conexión a la base de datos
async function getConnection() {
    try {
        return await sql.connect(config);
    } catch (err) {
        console.error('Error de conexión:', err);
    }
}

module.exports = {sql, getConnection};