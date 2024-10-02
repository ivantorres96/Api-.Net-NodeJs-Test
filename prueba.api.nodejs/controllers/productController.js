const express = require('express');
const { deleteProduct, updateProduct } = require('../Domains/product_domain');
const router = express.Router();

// Rutas
router.delete('/products', deleteProduct);
router.put('/products', updateProduct);

module.exports = router;