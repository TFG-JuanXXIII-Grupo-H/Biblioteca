import {z} from "zod";

export const sociosSchema = z.object({
  dni_socio: z
    .string()
    .length(10, {message: "The DNI must have 10 characters"}),
  nombre_socio: z
    .string()
    .min(1, {message: "Name is required"}),
  cnta_bancaria_socio: z
    .string()
    .min(1, {message: "Bank account is required"}),
  lugar_socio: z
    .string()
    .min(1, {message: "Location is required"}),
  cuota_pagada_socio: z
    .number().int()
    .min(0, {message: "Cuota is required"}),
  telefono_socio: z.number().int()
    .min(100000000, {message: "Phone number must have 9 digits"})
    .max(999999999, {message: "Phone number must have 9 digits"})
});
