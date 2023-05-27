# Defina as variáveis com suas informações específicas
$subscriptionId = Read-Host -Prompt "Entre com Subscription Id"
if($subscriptionId -eq [string]::empty) {
    break
}
$resourceGroupName = Read-Host -Prompt "Entre com o nome do Resource Group"
if($resourceGroupName -eq [string]::empty) {
    break
}

# Conecte-se à sua conta do Azure
Connect-AzAccount -SubscriptionId $subscriptionId

# Mostra mensagem de início
Write-Host "Iniciando exclusão do Resource Group: $resourceGroupName"

# Obtenha o número total de recursos no grupo de recursos
$resources = Get-AzResource -ResourceGroupName $resourceGroupName
$totalResources = $resources.Count
$deletedResources = 0

# Remova cada recurso individualmente
foreach ($resource in $resources) {
    Write-Host "Recurso - Apagando: " $resource.Name
    Remove-AzResource -ResourceId $resource.ResourceId -Force
    $deletedResources++
    Write-Host "Recurso - Apagado"
    
    # Exiba mensagem de progresso
    Write-Host "Recursos excluídos: $deletedResources de $totalResources"
}

# Remova o grupo de recursos
Write-Host "Resource Group - Apagando: " $resourceGroupName
Remove-AzResourceGroup -Name $resourceGroupName -Force
Write-Host "Resource Group - Apagado"

# Mostra mensagem de conclusão
Write-Host "Resource Group $resourceGroupName excluído com sucesso."
