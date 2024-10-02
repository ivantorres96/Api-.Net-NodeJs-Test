const {sql, getConnection} = require('../database_connection/db_context_ss');

//La funcion se encarga de actualizar un producto
async function updateProduct(product, res) {
    try {
        const pool = await getConnection();
        await pool.request()
            .input('id', sql.Int, product.body.id)
            .input('name', sql.NVarChar, product.body.name)
            .input('description', sql.NVarChar, product.body.description)
            .input('price', sql.Decimal, product.body.price)
            .input('stock', sql.Int, product.body.stock)
            .execute('UpdateProduct');
        res.status(200).send('Producto actualizado');
    } catch (e) {
        res.status(500).send('Error al actualizar el producto');
    }
}

// La funcion se encarga de eliminar un producto
async function deleteProduct(req, res) {
    const productId = req.query.id

    if (!productId) {
        return res.status(400).send('ID de producto es requerido');
    }

    try {
        const pool = await getConnection();
        await pool.request()
            .input('id', sql.Int, productId)
            .execute('DeleteProduct');
        res.status(200).send('Producto eliminado');
    } catch (e) {
        res.status(500).send('Error al eliminar el producto', e);
    }
}

module.exports = {updateProduct, deleteProduct};