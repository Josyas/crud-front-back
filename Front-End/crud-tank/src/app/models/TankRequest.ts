import { ProductTypeRequest } from "./ProductTypeRequest";

export class TankRequest{
    public Id!: number; 
    public Deposit!: string;
    public Capacity!: string;
    public ProductTypeId!: number;
    public ProductType: ProductTypeRequest | null = null; 
}