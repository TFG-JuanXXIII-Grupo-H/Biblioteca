import {db} from "../../db.js";

export const getSocios = (req, res) => {
    db.getConnection(async (err, conn) => {
        if (err) {
            conn.release()
            return res.status(500).json({error: "Error al obtener la conexión de la base de datos"});
        }

        try {
            const sociosQuery = "SELECT * FROM socios";
            conn.query(sociosQuery, (err, result) => {
                if (err) {
                    conn.release();
                    return res.status(500).json({error: "Error al obtener los socios"});
                }
                const socios = result.map(socio => ({
                    id: socio.num_socio,
                    dni: socio.dni_socio,
                    nombre: socio.nombre_socio,
                    cuentaBanc: socio.cnta_bancaria_socio,
                    dir: socio.lugar_socio,
                    cuota: socio.cuota_pagada_socio,
                    fechAlt: socio.fecha_alta_socio,
                    fechCad: socio.fecha_alta_socio, // Aquí puedes modificar si necesitas otro campo para 'fechCad'
                }));

                return res.status(200).json({
                    socios: socios,
                    message: "Mostrando socios...",
                });
            })
        } catch (err) {
            console.error("Error al mostrar los socios:", err);
            conn.release();
            return res.status(500).json({error: `Error al mostrar los socios: ${err.message}`});
        }
    });
}

export const addSocios = async (req, res) => {
    const {dni_socio, nombre_socio, cnta_bancaria_socio, lugar_socio, cuota_pagada_socio, telefono_socio} = req.body;

    db.getConnection(async (err, conn) => {
        if (err) {
            conn.release();
            return res.status(500).json({errors: ["Error al obtener la conexión de la base de datos"]});
        }

        try {
            const insertSocioQuery = "INSERT INTO socios (dni_socio, nombre_socio, cnta_bancaria_socio, lugar_socio, cuota_pagada_socio, telefono_socio) VALUES (?, ?, ?, ?, ?, ?)";
            conn.query(insertSocioQuery, [dni_socio, nombre_socio, cnta_bancaria_socio, lugar_socio, cuota_pagada_socio, telefono_socio], (err, result) => {
                if (err) {
                    return res.status(400).json({errors: [`Error al agregar el socio: ${err.message}`]});
                }

                return res.status(200).json({
                    message: "Socio agregado correctamente",
                    socio: {
                        id: result.insertId,
                    },
                });
            });
        } catch (err) {
            console.error("Error al agregar el socio:", err);
            conn.release();
            return res.status(500).json({errors: [`Error al agregar el socio: ${err.message}`]});
        }
    });
};