const { deleteProduct, updateProduct } = require('../Domains/product_domain');

describe('Actualizar producto', () => {
    let req, res;

    beforeEach(() => {
        req = {
            body: {
                id: 21,
                name: 'Tenis Nike 01',
                description: 'Descripción suave',
                price: 10000.00,
                stock: 10
            }
        };

        res = {
            status: jest.fn().mockReturnThis(),
            send: jest.fn()
        };
    });

    test('Si el producto se actualiza de forma exitosa', async () => {
        await updateProduct(req, res);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(res.send).toHaveBeenCalledWith('Producto actualizado');
    });
});


describe('Eliminar producto', () => {
    let req, res;

    beforeEach(() => {
        req = {
            query: {
                id: 12
            }
        };
        res = {
            status: jest.fn().mockReturnThis(),
            send: jest.fn()
        };
    });

    test('Se elimino con exito el producto', async () => {
        await deleteProduct(req, res);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(res.send).toHaveBeenCalledWith('Producto eliminado');
    });
});