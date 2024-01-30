import { Component } from '@angular/core';
import { ProductTypeRequest } from 'src/app/models/ProductTypeRequest';
import { RequestDeleteProducttypeService } from 'src/app/services/request-delete-producttype.service';
import { RequestProductTypeService } from 'src/app/services/request-product-type.service';
import { RequestUpdateProducttypeService } from 'src/app/services/request-update-producttype.service';
import { ResponseListProducttypeService } from 'src/app/services/response-list-producttype.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-product-type',
  templateUrl: './product-type.component.html',
  styleUrls: ['./product-type.component.scss']
})
export class ProductTypeComponent {
  productTypeModel!: ProductTypeRequest;
  productTypes: ProductTypeRequest[] = [];
  public isModalOpen = false;

  constructor(private productTypeService: RequestProductTypeService,
              private productTypeListService: ResponseListProducttypeService,
              private productTypeUpdateService: RequestUpdateProducttypeService,
              private productTypeDeleteService: RequestDeleteProducttypeService)
  {
      this.productTypeModel = new ProductTypeRequest
      this.ListProductType();
  }
  
  public async createProdutctTypeEvent(){
    if (this.validarCampos())
    {
      (await this.productTypeService.createProductType(this.productTypeModel)).subscribe(
        (response) => {
          this.ListProductType();
          Swal.fire({
            icon: 'success',
            title: 'Salvo com sucesso!',
            showConfirmButton: true 
          });
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

      this.productTypeModel = new ProductTypeRequest();
    }
  }

  public async updateProdutctTypeEvent(){
    if (this.validarCampos())
    {
      (await this.productTypeUpdateService.updateProductType(this.productTypeModel)).subscribe(
        (response) => {
          this.ListProductType();
          Swal.fire({
            icon: 'success',
            title: 'Atualizado com sucesso!',
            showConfirmButton: true 
          });
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

  public async deleteProdutctTypeEvent(){
    if (this.validarCampos())
    {
      (await this.productTypeDeleteService.deleteProductType(this.productTypeModel)).subscribe(
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

  public excluirType(id: number, name: string) {
    Swal.fire({
      title: 'Tem certeza?',
      text: `Você deseja excluir o item?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.excluirItem(id, name);
      }
    });
  }

  excluirItem(id: number, name: string) {
    this.productTypeModel.Id = id;
    this.productTypeModel.Name = name;
    this.deleteProdutctTypeEvent();
    this.productTypeModel = new ProductTypeRequest();
  }

  public ListProductType(){
    (this.productTypeListService.getAllProductTypes()).subscribe(
      (response) => {
        console.log(response)
        this.productTypes = response;
      },
      (httpError) => {
        Swal.fire('Erro', httpError.error, 'error');
      }
    );
  }
  
  async selecionarType(id: number, name: string)
  {
    this.productTypeModel.Id = id;
    this.productTypeModel.Name = name;
  }

  private validarCampo(campo: any, mensagem: string): boolean {
    if (!campo) {
      Swal.fire('Erro', `Campo ${mensagem} é obrigatório`, 'error');
      return false;
    }
    return true;
  }

  private validarCampos(): boolean {
    const campos = this.productTypeModel;
  
    return (
      this.validarCampo(campos.Name, 'nome') 
    );
  }
  openModal() {
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
  }
}