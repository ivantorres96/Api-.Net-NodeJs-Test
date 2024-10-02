const express = require('express');
const productRoutes = require('./controllers/productController');
const app = express();
const port = 3000;

app.use(express.json());
app.use('/api', productRoutes);

app.listen(port, () => {
    console.log(`Servidor escuchando en http://localhost:${port}`);
});