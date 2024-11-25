import {z} from "zod";

export const registerSchema = z.object({
  username: z
    .string({
      required_error: "Username is required",
    })
    .min(3, {message: "Username must have at least 3 chars"}),
  email: z
    .string({
      required_error: "Email is required",
    })
    .email({
      message: "Email is not valid",
    })
    .min(3, {message: "Email must have at least 3 chars"}),
  password: z
    .string({
      required_error: "Password is required",
    })
    .min(6, {
      message: "Password must have at least 6 chars",
    }),
  rango: z.
    string().
    optional()
});

export const loginSchema = z.object({
  username: z
    .string({
      required_error: "Username is required",
    })
    .min(3, {message: "Username must have at least 3 chars"}),
  password: z
    .string({
      required_error: "Password is required",
    })
    .min(6, {
      message: "Password must have at least 6 chars",
    }),
});