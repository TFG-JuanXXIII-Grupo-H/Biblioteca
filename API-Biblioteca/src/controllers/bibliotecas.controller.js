import {db} from "../../db.js";

export const getBibliotecas = (req, res) => {
    db.getConnection(async (err, conn) => {
        if (err) {
            conn.release()
            return res.status(500).json({error: "Error al obtener la conexión de la base de datos"});
        }

        try {
            const bibliotecasQuery = "SELECT * FROM socios";
            conn.query(bibliotecasQuery, (err, result) => {
                if (err) {
                    conn.release();
                    return res.status(500).json({error: "Error al obtener las bibliotecas"});
                }
                const bibliotecas = result.map(biblioteca => ({
                    id: biblioteca.cod_biblioteca,
                    provincia: biblioteca.provincia_biblioteca
                }));

                return res.status(200).json({
                    socios: bibliotecas,
                    message: "Mostrando bibliotecas...",
                });
            })
        } catch (err) {
            console.error("Error al mostrar las bibliotecas:", err);
            conn.release();
            return res.status(500).json({error: `Error al mostrar las bibliotecas: ${err.message}`});
        }
    });
}

export const addBiblioteca = (req, res) => {
    const {provincia_biblioteca} = req.body
    db.getConnection(async (err, conn) => {
        if (err) {
            conn.release()
            return res.status(500).json({error: "Error al obtener la conexión de la base de datos"});
        }

        try {
            const insertBibliotecaQuery = "INSERT INTO `bibliotecas` (`provincia_biblioteca`) VALUES (?),";
            conn.query(insertBibliotecaQuery, [provincia_biblioteca],(err) => {
                if (err) {
                    conn.release();
                    return res.status(500).json({error: "Error al obtener las bibliotecas"});
                }

                return res.status(200).json({
                    message: "Biblioteca añadida...",
                });
            })
        } catch (err) {
            console.error("Error al añadir la biblioteca:", err);
            conn.release();
            return res.status(500).json({error: `Error al añadir la biblioteca: ${err.message}`});
        }
    });
}