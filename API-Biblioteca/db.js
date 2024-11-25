import mysql from 'mysql2'
import dotenv from "dotenv"; dotenv.config()

export const db = mysql.createPool({
    connectionLimit: 10,
    host: process.env.HOST || 'localhost',
    user: process.env.USER || 'root',
    password: process.env.PASSWORD || '',
    database: process.env.DATABASE || 'nodejs-login'
})

export const connectDB = () => {
    console.log(`MYSQL Connected to ${process.env.DATABASE || 'nodejs-login'} ...`);
};

export const endConexion = async () => {
    db.end((err) => {
        if(err){
            console.log(err)
        }else {
            console.log(`MYSQL conexion has successfully ended ...`)
        }
    })
}