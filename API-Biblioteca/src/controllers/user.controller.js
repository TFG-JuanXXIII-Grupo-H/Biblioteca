import {db} from "../../db.js";
import bcrypt from 'bcryptjs';

export const register = (req, res) => {
    const {username, email, password} = req.body;

    db.getConnection(async (err, conn) => {
        if (err) {
            conn.release()
            return res.status(500).json({error: "Error al obtener la conexión de la base de datos"});
        }

        try {
            const userExistsQuery = "SELECT COUNT(*) as rowCount FROM usuarios WHERE correo_usuario = ?";
            conn.query(userExistsQuery, [email], (err, result) => {
                if (err) {
                    conn.release();
                    return res.status(500).json({error: "Error al verificar el usuario"});
                }

                if (result[0].rowCount > 0) {
                    conn.release();
                    return res.status(400).json({error: "El usuario ya existe"});
                }

                const insertUserQuery = `
                    INSERT INTO usuarios (nombre_usuario, correo_usuario)
                    VALUES (?, ?)
                `;
                conn.query(insertUserQuery, [username, email], async (err, result) => {
                    if (err) {
                        conn.release();
                        return res.status(400).json({error: `Error al registrarse: ${err.message}`});
                    }

                    const userId = result.insertId;
                    const hashedPassword = await bcrypt.hash(password, 8);

                    const insertPasswordQuery = `
                        INSERT INTO almacen (id_almacen, contenido)
                        VALUES (?, ?)
                    `;
                    conn.query(insertPasswordQuery, [userId, hashedPassword], (err) => {
                        if (err) {
                            conn.release();
                            return res.status(400).json({error: `Error al guardar la contraseña: ${err.message}`});
                        }

                        const getUserQuery = "SELECT * FROM usuarios WHERE id_usuario = ?";
                        conn.query(getUserQuery, [userId], (err, userResult) => {
                            conn.release();
                            if (err) {
                                return res.status(400).json({error: `Error al obtener el usuario: ${err.message}`});
                            }

                            const user = userResult[0];
                            return res.status(200).json({
                                user: {
                                    id: user.id_usuario,
                                    name: user.nombre_usuario,
                                    email: user.correo_usuario,
                                    rango: user.rango,
                                },
                                message: "Registrado correctamente",
                            });
                        });
                    });
                });
            });
        } catch (err) {
            console.error("Error al registrar el usuario:", err);
            conn.release();
            return res.status(500).json({error: `Error al registrar el usuario ${err.message}`});
        }
    });
};
export const login = async (req, res) => {
    const {username, password} = req.body;

    db.getConnection(async (err, conn) => {
        if (err) {
            conn.release();
            return res.status(500).json({errors: ["Error al obtener la conexión de la base de datos"]});
        }

        try {
            const userQuery = "SELECT * FROM usuarios WHERE nombre_usuario = ?";
            conn.query(userQuery, [username], async (err, userResult) => {
                if (err) {
                    conn.release();
                    return res.status(500).json({errors: ["Error al verificar el usuario"]});
                }

                if (userResult.length === 0) {
                    conn.release();
                    return res.status(400).json({errors: ["Usuario no encontrado"]});
                }

                const user = userResult[0];

                const passwordQuery = "SELECT contenido FROM almacen WHERE id_almacen = ?";
                conn.query(passwordQuery, [user.id_usuario], async (err, passwordResult) => {
                    conn.release();
                    if (err) {
                        return res.status(500).json({errors: ["Error al verificar la contraseña"]});
                    }

                    if (passwordResult.length === 0) {
                        return res.status(400).json({errors: ["Contraseña no encontrada"]});
                    }

                    const isPasswordValid = await bcrypt.compare(password, passwordResult[0].contenido);
                    if (!isPasswordValid) {
                        return res.status(400).json({errors: ["Contraseña incorrecta"]});
                    }

                    return res.status(200).json({
                        user: {
                            id: user.id_usuario,
                            name: user.nombre_usuario,
                            email: user.correo_usuario,
                            rango: user.rango,
                        },
                        message: "Logueado correctamente",
                    });
                });
            });
        } catch (err) {
            console.error("Error al iniciar sesión:", err);
            conn.release();
            return res.status(500).json({errors: [`Error al iniciar sesión: ${err.message}`]});
        }
    });
};
