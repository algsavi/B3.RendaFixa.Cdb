export interface CdbRequest {
    valorInicial: number;
    prazoEmMeses: number;
}

export interface CdbResponse {
    valorBruto: number;
    valorLiquido: number;
}