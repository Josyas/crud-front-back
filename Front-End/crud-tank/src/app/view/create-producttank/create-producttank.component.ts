import { Component } from '@angular/core';
import { ProductTypeRequest } from 'src/app/models/ProductTypeRequest';
import { TankRequest } from 'src/app/models/TankRequest';
import { RequestCreateTankService } from 'src/app/services/request-create-tank.service';
import { RequestDeleteTankService } from 'src/app/services/request-delete-tank.service';
import { RequestUpdateTankService } from 'src/app/services/request-update-tank.service';
import { ResponseListProducttypeService } from 'src/app/services/response-list-producttype.service';
import { ResponseListTankService } from 'src/app/services/response-list-tank.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-producttank',
  templateUrl: './create-producttank.component.html',
  styleUrls: ['./create-producttank.component.scss']
})
export class CreateProducttankComponent {
  productTypes: any[] = []; 
  tankModel!: TankRequest;
  productTypeModel!: ProductTypeRequest;
  productTank: TankRequest[] = [];
  p: number = 0;
  public isModalOpen = false;

  constructor(private ListTankService: ResponseListTankService,
              private productTypeListService: ResponseListProducttypeService,
              private createTankService: RequestCreateTankService,
              private updateTankService: RequestUpdateTankService,
              private deleteTankService: RequestDeleteTankService) { 
              this.tankModel = new TankRequest();
              this.productTypeModel = new ProductTypeRequest();
  }

  ngOnInit(){
    this.ListProductType();
    this.ListTank();
  }

  public async createTankEvent(){
    if (this.validarCampos())
    {
      (await this.createTankService.createTank(this.tankModel)).subscribe(
        (response) => {
          this.ListProductType();
          this.ListTank();
          Swal.fire({
            icon: 'success',
            title: 'Salvo com sucesso!',
            showConfirmButton: true 
          });
        },
        (httpError) => {
          console.log(httpError)
          Swal.fire({
            icon: 'error',
            title: 'Erro',
            text: httpError.error,
            confirmButtonText: 'OK'
          });
        }
      );

      this.tankModel = new TankRequest();
    }
  }

  public async updateProdutctTypeEvent(){
    if (this.validarCampos())
    {
      (await this.updateTankService.updateTank(this.tankModel)).subscribe(
        (response) => {
          this.ListProductType();
          Swal.fire({
            icon: 'success',
            title: 'Atualizado com sucesso!',
            showConfirmButton: true 
          });
          this.ListTank();
        },
        (httpError) => {
          Swal.fire({
            icon: 'error',
            title: 'Erro',
            text: httpError.error,
            confirmButtonText: 'OK'
          });
        }
      );
      this.closeModal();
    }
  }

  public async deleteTankEvent(){
    if (this.validarCampos())
    {
      (await this.deleteTankService.deleteTank(this.tankModel)).subscribe(
        (response) => {
          this.ListProductType();
        },
        (httpError) => {
          Swal.fire({
            icon: 'error',
            title: 'Erro',
            text: httpError.error,
            confirmButtonText: 'OK'
          });
        }
      );
    }
  }

  public excluirTank(id: number, deposit: string, capacity: string, productTypeId: number) {
    Swal.fire({
      title: 'Tem certeza?',
      text: `Você deseja excluir o item?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        debugger
        this.excluirItem(id, deposit, capacity, productTypeId);
        this.deleteTankEvent();
      }
    });
  }

  excluirItem(id: number, deposit: string, capacity: string, productTypeId: number) {
    this.tankModel.Id = id;
    this.tankModel.Deposit = deposit;
    this.tankModel.Capacity = capacity;
    this.tankModel.ProductTypeId = productTypeId;
    this.productTypeModel = new ProductTypeRequest();
  }
  
  public ListTank(){
    (this.ListTankService.getAllTanks()).subscribe(
      (response) => {
        this.productTank = response;
        console.log(response)
      },
      (httpError) => {
        Swal.fire('Erro', httpError.error, 'error');
      }
    );
  }

  public ListProductType(){
    (this.productTypeListService.getAllProductTypes()).subscribe(
      (response) => {
        this.productTypes = response;
        console.log(response)
      },
      (httpError) => {
        Swal.fire('Erro', httpError.error, 'error');
      }
    );
  }

  private validarCampo(campo: any, mensagem: string): boolean {
    if (!campo) {
      Swal.fire('Erro', `Campo ${mensagem} é obrigatório`, 'error');
      return false;
    }
    return true;
  }

  private validarCampos(): boolean {
    const campos = this.tankModel;
  
    return (
      this.validarCampo(campos.Capacity, 'Capacidade'),
      this.validarCampo(campos.Deposit, 'Desposito'),
      this.validarCampo(campos.ProductTypeId, 'Categoria')
    );
  }

  async selecionarTank(id: number, deposit: string, capacity: string, productTypeId: number)
  {
    this.tankModel.Id = id;
    this.tankModel.Deposit = deposit;
    this.tankModel.Capacity = capacity;
    this.tankModel.ProductTypeId = productTypeId;
  }

  openModal() {
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
  }
}
