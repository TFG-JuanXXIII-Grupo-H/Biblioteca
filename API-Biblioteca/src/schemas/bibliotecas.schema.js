import {z} from "zod";

export const bibliotecasSchema = z.object({
    provincia_biblioteca: z
        .string()
        .min(1, {message: "provincia_biblioteca is required"}),
})