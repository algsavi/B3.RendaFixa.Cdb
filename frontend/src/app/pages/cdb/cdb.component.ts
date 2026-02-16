import { Component } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CdbService } from '../../services/cdb.service';
import { CdbResponse } from '../../models/cdb.model';
import { finalize } from 'rxjs/operators';
import { ChangeDetectorRef } from '@angular/core';
import { NgxMaskDirective } from 'ngx-mask';

@Component({
    selector: 'app-cdb',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule, NgxMaskDirective],
    templateUrl: './cdb.component.html',
})
export class CdbComponent {
    loading = false;
    erro: string | null = null;
    resultado: CdbResponse | null = null;

    form!: FormGroup;

    constructor(private fb: FormBuilder, private cdb: CdbService, private cd: ChangeDetectorRef) {
        this.form = this.fb.group({
            valorInicial: [null as number | null, [Validators.required, Validators.min(0.01)]],
            prazoEmMeses: [null as number | null, [Validators.required, Validators.min(2)]],
        });
    }

    calcular(): void {
        this.erro = null;
        this.resultado = null;

        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        this.loading = true;

        const valorInicial = Number(this.form.get('valorInicial')?.value);
        const prazoEmMeses = Number(this.form.get('prazoEmMeses')?.value);

        const req = { valorInicial, prazoEmMeses };

        this.cdb.calcular(req)
            .pipe(finalize(() => (this.loading = false)))
            .subscribe({
                next: (res) => {
                    this.resultado = res;
                    this.cd.detectChanges();
                },
                error: (e) => {
                    this.erro =
                        e?.error?.erro ||
                        e?.error?.message ||
                        'Erro ao calcular investimento.';
                },
            });
    }

    brl(v: number | null | undefined): string {
        return (v ?? 0).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
    }
}
